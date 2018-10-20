using System;
using System.ComponentModel;
using Telegram.Bot;

namespace Server
{
    public class Bot
    {
        BackgroundWorker bw;

        public void RunBot()
        {
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
                var bot = new TelegramBotClient(key); // инициализируем API
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
                            await bot.SendTextMessageAsync(message.Chat.Id, "У нас есть вот такой бот. Это он. Тот самый. Ну, который вам нужен", replyToMessageId: message.MessageId);
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

                }
            }
            catch (Telegram.Bot.Exceptions.ApiRequestException ex)
            {
                Console.WriteLine(ex.Message); // если ключ не подошел - пишем об этом в консоль отладки
            }
        }
    }
}