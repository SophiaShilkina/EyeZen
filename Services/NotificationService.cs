using Microsoft.Toolkit.Uwp.Notifications;
using EyeZen.Utilities;

namespace EyeZen.Services
{
    public class NotificationService
    {
        private Timer? _timerWarmUp;
        private Timer? _timerRest;
        private DateTime _programStartTime;
        private readonly Random _random = new Random();

        public void Start()
        {
            _programStartTime = DateTime.Now;
            Console.WriteLine("Start вызван в " + _programStartTime);
            _timerWarmUp = new Timer(SendNotificationWarmUp, null, TimeSpan.FromMinutes(1), TimeSpan.FromMinutes(1));
            _timerRest = new Timer(SendNotificationRest, null, TimeSpan.FromMinutes(3), TimeSpan.FromMinutes(3));
            
        }

        public void Stop()
        {
            Console.WriteLine("Stop вызван в " + DateTime.Now);
            _timerWarmUp?.Change(Timeout.Infinite, 0);
            _timerRest?.Change(Timeout.Infinite, 0);
        }

        private void SendNotificationWarmUp(object? state)
        {
            var now = DateTime.Now;
            var minutesSinceStart = Math.Round((now - _programStartTime).TotalMinutes);
            Console.WriteLine(minutesSinceStart);
            
            if (minutesSinceStart % 3 == 0)
            {
                Console.WriteLine("SendNotificationWarmUp пропущено (время для уведомления Rest)");
                return;
            }
            
            Console.WriteLine("SendNotificationWarmUp вызван в " + now);
            
            int randomNumber = _random.Next(0, 2); 
            Console.WriteLine("randomNumber = " + randomNumber);
            
            if (randomNumber == 0)
            {
                new ToastContentBuilder()
                    .AddText(LocalizationManager.GetString("WarmUpNotificationTitle"))
                    .AddText(LocalizationManager.GetString("WarmUpNotification1"))
                    .Show();
            }
            else
            {
                new ToastContentBuilder()
                    .AddText(LocalizationManager.GetString("WarmUpNotificationTitle"))
                    .AddText(LocalizationManager.GetString("WarmUpNotification2"))
                    .Show();
            }
        }
        
        private void SendNotificationRest(object? state)
        {
            Console.WriteLine("SendNotificationRest вызван в " + DateTime.Now);
            
            int randomNumber = _random.Next(0, 2); 
            
            if (randomNumber == 0)
            {
                new ToastContentBuilder()
                    .AddText(LocalizationManager.GetString("RestNotificationTitle"))
                    .AddText(LocalizationManager.GetString("RestNotification1"))
                    .Show();
            }
            else
            {
                new ToastContentBuilder()
                    .AddText(LocalizationManager.GetString("RestNotificationTitle"))
                    .AddText(LocalizationManager.GetString("RestNotification2"))
                    .Show();
            }
        }
    }
}