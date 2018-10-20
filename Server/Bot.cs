using System;
using System.ComponentModel;

namespace PosterStaBot
{
    public class Bot
    {
        BackgroundWorker bw;

        public Bot()
        {
            RunBot();
        }

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
                var Bot = new Telegram.Bot.TelegramBotClient(key); // инициализируем API
                await Bot.SetWebhookAsync("");
                //Bot.SetWebhook(""); // Обязательно! убираем старую привязку к вебхуку для бота
                int offset = 0; // отступ по сообщениям
                while (true)
                {
                    var updates = await Bot.GetUpdatesAsync(offset); // получаем массив обновлений

                    foreach (var update in updates) // Перебираем все обновления
                    {
                        var message = update.Message;
                        if (message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
                        {
                            await Bot.SendTextMessageAsync(message.Chat.Id, "тест",
                                    replyToMessageId: message.MessageId);
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