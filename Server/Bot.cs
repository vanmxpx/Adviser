using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using Telegram.Bot;

namespace Server
{
    public class Bot
    {
        BackgroundWorker bw;
        TelegramBotClient bot;
        int nextHour = 19;

        List<Selection> mockSelection;

        public void RunBot()
        {
            FillMockSelection();
            this.bw = new BackgroundWorker();
            this.bw.DoWork += this.bw_DoWork; // метод bw_DoWork будет работать асинхронно

            //var Bot = new TelegramBotClient("lljlk");
            if (this.bw.IsBusy != true)
            {
                this.bw.RunWorkerAsync("655832225:AAE_iUdaiN_Al9ZIWFUmBEnqgwroMtZGe5Y"); // передаем эту переменную в виде аргумента методу bw_DoWork
            }
        }

        async void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            var key = e.Argument as String; // получаем ключ из аргументов
            try
            {
                bot = new TelegramBotClient(key); // инициализируем API
                var me = bot.GetMeAsync().Result;
                await bot.SetWebhookAsync("");
                //Bot.SetWebhook(""); // Обязательно! убираем старую привязку к вебхуку для бота
                int offset = 0; // отступ по сообщениям
                while (true)
                {
                    var updates = await bot.GetUpdatesAsync(offset); // получаем массив обновлений

                    foreach (var update in updates) // Перебираем все обновления
                    {
                        var message = update.Message;
                        // reply buttons
                        if (message.Text == "/start")
                        {
                            var keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                            {
                                Keyboard = new[] {
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("Выборка"),
                                                    new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("Фудкост"),
                                                    new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("Настройки"),
                                                },
                                            },
                                ResizeKeyboard = true
                            };
                            await bot.SendTextMessageAsync(message.Chat.Id, "Приветствую в Poster Bot!",
                             Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, keyboard);
                        }
                        // inline buttons
                        // if (message.Text == "/ibuttons")
                        // {
                        //     var b = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardButton();
                        //     var keyboard = new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardMarkup(
                        //                             new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardButton[][]
                        //                             {
                        //                                     // First row
                        //                                     new [] {
                        //                                         // First column
                        //                                         new Telegram.Bot.Types.ReplyMarkups.InlineKeyboardButton(),

                        //                                         // Second column
                        //                                         new Telegram.Bot.Types.InlineKeyboardButton("два","callback2"),
                        //                                     },
                        //                             }
                        //                         );

                        //     await Bot.SendTextMessageAsync(message.Chat.Id, "Давай накатим, товарищ, по одной!", false, false, 0, keyboard, Telegram.Bot.Types.Enums.ParseMode.Default);
                        // }
                        if (message.Text.ToLower() == "выборка")
                        {
                            await bot.SendTextMessageAsync(message.Chat.Id, message.Chat.Id.ToString());
                            SendSelection(message.Chat.Id);
                        }
                        if (message.Text.ToLower() == "фудкост")
                        {
                            await bot.SendTextMessageAsync(message.Chat.Id, "У нас есть вот такой бот. Это он. Тот самый. Ну, который вам нужен", replyToMessageId: message.MessageId);
                        }
                        if (message.Text.ToLower() == "настройки")
                        {
                            await bot.SendTextMessageAsync(message.Chat.Id, "У нас есть вот такой бот. Это он. Тот самый. Ну, который вам нужен", replyToMessageId: message.MessageId);
                        }
                        if (message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
                        {
                            // await bot.SendTextMessageAsync(message.Chat.Id, "тест",
                            //         replyToMessageId: message.MessageId);
                            // if (message.Text == "/saysomething")
                            // {
                            //     // в ответ на команду /saysomething выводим сообщение
                            //     await Bot.SendTextMessageAsync(message.Chat.Id, "тест",
                            //         replyToMessageId: message.MessageId);
                            // }
                        }
                        offset = update.Id + 1;
                    }

                    if (DateTime.Now.Hour == nextHour)
                    {
                        // TODO: get 
                        Console.WriteLine(nextHour);
                        await bot.SendTextMessageAsync(555088775, "Нотификация!");
                        nextHour++;
                    }
                }
            }
            catch (Telegram.Bot.Exceptions.ApiRequestException ex)
            {
                Console.WriteLine(ex.Message); // если ключ не подошел - пишем об этом в консоль отладки
            }
        }

        async void SendSelection(long ChatId)
        {
            // for (int i = 0; i < 10; i++)
            // {
            //     // await bot.SendTextMessageAsync(ChatId,
            //     // "Кофе \n ------ \n Себестоимость -  35.5 грн \n Кол-во проданных - 45 ед.\n Выручка - 120 000 грн\n ");
            // }
            var userModel = mockSelection
                .Where(item => item.ChatId == ChatId)
                .FirstOrDefault();
            for (int i = 0; i < userModel.Models.Count; i++)
            {
                await bot.SendTextMessageAsync(userModel.ChatId,
                userModel.Models[i].Name + "\n ------ \n Себестоимость - " 
                + userModel.Models[i].Price + "грн \n Кол-во проданных - " 
                + userModel.Models[i].AmountSelled + "ед.\n Выручка - " 
                + userModel.Models[i].Money + " грн\n ");
            }
        }

        void FillMockSelection()
        {
            var product1 = new Product();
            product1.Price = 13.43d;
            product1.AmountSelled = 23;
            product1.Name = "Kofe";
            product1.Money = 123000.0d;
            var product2 = new Product();
            product1.Price = 213.43d;
            product2.AmountSelled = 234;
            product1.Name = "Vodka";
            product1.Money = 234123000.0d;

            var selection = new Selection();
            selection.ChatId = 555088775;
            selection.Hour = 19;
            selection.Models.Add(product1);
            selection.Models.Add(product2);
        }
    }
}