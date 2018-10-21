using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using Telegram.Bot;
using Server.Enums;
using Server.ModelsBot;
using System.Text.RegularExpressions;

namespace Server
{
    public class Bot
    {
        BackgroundWorker bw;
        TelegramBotClient bot;
        int nextHour = DateTime.Now.Hour;
        int nextMinute = DateTime.Now.Minute + 1;

        List<User> mockSelection = new List<User>();
        List<Product> models = new List<Product>();

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
                        
                        var user = mockSelection.Where(t => t.ChatId == message.Chat.Id).FirstOrDefault();
                        if(user == null)
                        {
                            Console.WriteLine(message.Chat.Id);
                            CreateNewUser(message.Chat.Id);
                        } 
                        if (message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
                        {
                            if (user.Status == UserStatus.InMenu)
                            {
                                if (message.Text == "/start" || message.Text.ToLower() == "назад")
                                {
                                    ToMainMenu(user, "Приветствую в Poster Bot!");
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
                                    //await bot.SendTextMessageAsync(message.Chat.Id, message.Chat.Id.ToString());
                                    SendSelection(message.Chat.Id);
                                }
                                if (message.Text.ToLower() == "фудкост")
                                {

                                }
                                if (message.Text.ToLower() == "настройки")
                                {
                                    var keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                                    {
                                        Keyboard = new[] {
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("Настройки выборки"),
                                                    new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("Настройки фудкоста"),
                                                },
                                            },
                                        ResizeKeyboard = true
                                    };
                                    await bot.SendTextMessageAsync(message.Chat.Id, "Выберите категорию",
                                     Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, keyboard);

                                }
                                if (message.Text.ToLower() == "настройки выборки")
                                {
                                    var keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                                    {
                                        Keyboard = new[] {
                                                new[] // row 1
                                                {
                                                    new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("Время нотификации"),
                                                    new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("Категории товаров"),
                                                },
                                            },
                                        ResizeKeyboard = true
                                    };
                                    await bot.SendTextMessageAsync(message.Chat.Id, "Выберите категорию",
                                     Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, keyboard);
                                }
                                if (message.Text.ToLower() == "время нотификации")
                                {
                                    await bot.SendTextMessageAsync(message.Chat.Id, "Введите время в формате [часы:минуты]. К примеру \"09:40\"",
                                     Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, null);
                                     user.Status = UserStatus.AwaitingNotificationTime;
                                }
                                if (message.Text.ToLower() == "категории товаров")
                                {
                                    await bot.SendTextMessageAsync(message.Chat.Id, "Введите через запятую номера товаров. К примеру \"1,4,5,6\"",
                                     Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, null);
                                     user.Status = UserStatus.AwaitingProductCategories;

                                    string productMes = "Категории товаров:\n";
                                    for (int i=0; i<models.Count;i++)
                                    {
                                        productMes+= (i+1) + " - " + models[i].Name + "\n";
                                    }
                                    await bot.SendTextMessageAsync(message.Chat.Id, productMes,
                                     Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, null);
                                }
                                // if (message.Text.ToLower() == "часы" || message.Text.ToLower() == "минуты")
                                // {
                                //     var keyboard = new Telegram.Bot.Types.ReplyMarkups.ReplyKeyboardMarkup
                                //     {
                                //         Keyboard = new[] {
                                //                 new[] // row 1
                                //                 {
                                //                     new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("Часы"),
                                //                     new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("Минуты"),
                                //                     new Telegram.Bot.Types.ReplyMarkups.KeyboardButton("Назад")
                                //                 },
                                //             },
                                //         ResizeKeyboard = true
                                //     };

                                //     bot.OnMessage += async (object er, Telegram.Bot.Args.MessageEventArgs el) =>
                                //     {
                                //         await bot.SendTextMessageAsync(message.Chat.Id, "Данные упешно введены",
                                //      Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, keyboard);
                                //     };
                                // }
                            }
                            else if (user.Status == UserStatus.AwaitingNotificationTime)
                            {
                                try
                                {
                                    ConvertTime(user, message.Text);
                                    user.Status = UserStatus.InMenu;
                                    ToMainMenu(user, "Данные упешно введены");
                                }
                                catch
                                {
                                    SendErrorMessage(message.Chat.Id);
                                }
                            }
                            else if (user.Status == UserStatus.AwaitingProductCategories)
                            {
                                try
                                {
                                    ConvertProducts(user, message.Text);
                                    user.Status = UserStatus.InMenu;
                                    ToMainMenu(user, "Данные упешно введены");
                                }
                                catch
                                {
                                    SendErrorMessage(message.Chat.Id);
                                }
                            }
                        }
                        offset = update.Id + 1;
                    }

                    if (DateTime.Now.Hour == nextHour && DateTime.Now.Minute == nextMinute)
                    {
                        // TODO: get 
                        List<User> notifUsers = mockSelection.Where(t => t.Hour == nextHour)
                        .Where(t => t.Minutes == nextMinute).ToList();

                        for (int i = 0; i < notifUsers.Count; i++)
                        {
                            SendSelection(notifUsers[i].ChatId);
                        }

                        if (nextMinute == 59)
                        {
                            nextMinute = 00;
                            nextHour++;
                        }
                        else
                        {
                            nextMinute++;
                        }
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
                await bot.SendTextMessageAsync(userModel.ChatId, " " +
                userModel.Models[i].Name + "\n ------ \n Себестоимость - "
                + userModel.Models[i].Price + " грн \n Кол-во проданных - "
                + userModel.Models[i].AmountSelled + " ед.\n Выручка - "
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
            product2.Price = 213.43d;
            product2.AmountSelled = 234;
            product2.Name = "Vodka";
            product2.Money = 234123000.0d;
            var product3 = new Product();
            product3.Price = 213.43d;
            product3.AmountSelled = 234;
            product3.Name = "Pirog";
            product3.Money = 234123000.0d;
            var product4 = new Product();
            product4.Price = 213.43d;
            product4.AmountSelled = 234;
            product4.Name = "Kulish";
            product4.Money = 234123000.0d;

            models.Add(product1);
            models.Add(product2);
            models.Add(product3);
            models.Add(product4);

            var selection = new User();
            selection.Status = UserStatus.InMenu;
            selection.ChatId = 341195271;
            selection.Hour = 21;
            selection.Minutes = 00;
            selection.Models.Add(product1);
            selection.Models.Add(product2);

            var selection1 = new User();
            selection1.Status = UserStatus.InMenu;
            selection1.ChatId = 555088775;
            selection1.Hour = 21;
            selection1.Minutes = 00;
            selection1.Models.Add(product1);
            selection1.Models.Add(product2);

            var selection2 = new User();
            selection2.Status = UserStatus.InMenu;
            selection2.ChatId = 352478805;
            selection2.Hour = 21;
            selection2.Minutes = 00;
            selection2.Models.Add(product1);
            selection2.Models.Add(product2);

            mockSelection.Add(selection);
            mockSelection.Add(selection1);
            mockSelection.Add(selection2);
        }

        void CreateNewUser(long chatId)
        {
            var product1 = new Product();
            product1.Price = 13.43d;
            product1.AmountSelled = 23;
            product1.Name = "Kofe";
            product1.Money = 123000.0d;
            var product2 = new Product();
            product2.Price = 213.43d;
            product2.AmountSelled = 234;
            product2.Name = "Vodka";
            product2.Money = 234123000.0d;

            var selection2 = new User();
            selection2.Status = UserStatus.InMenu;
            selection2.ChatId = chatId;
            selection2.Hour = 21;
            selection2.Minutes = 00;
            selection2.Models.Add(product1);
            selection2.Models.Add(product2);
        }

        void ConvertTime(User user, string timeStri)
        {
            string hour="", minutes="";
            bool isMinute = false;
            for (int i=0;i<timeStri.Length;i++)
            {
                if (timeStri[i] != ':')
                {
                    if(isMinute)
                    {
                        minutes+=timeStri[i];
                    }
                    else
                    {
                        hour+=timeStri[i];
                    }
                }
                else
                {
                    isMinute=true;
                }
            }
            int minutesInt = int.Parse(minutes);
            int hourInt = int.Parse(hour);
            user.Minutes = minutesInt;
            user.Hour = hourInt;
        }

        void ConvertProducts(User user, string productsStri)
        {
            string[] lines = Regex.Split(productsStri, ",");
            user.Models.Clear();
            foreach (string line in lines)
            {
                user.Models.Add(models[int.Parse(line)-1]);
            }
        }

        async void SendErrorMessage(long chatId)
        {
            await bot.SendTextMessageAsync(chatId, "Неправельно введены данные",
                Telegram.Bot.Types.Enums.ParseMode.Default);
        }

        async void ToMainMenu(User user, string text)
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
            await bot.SendTextMessageAsync(user.ChatId, text,
                Telegram.Bot.Types.Enums.ParseMode.Default, false, false, 0, keyboard);
        }
    }
}