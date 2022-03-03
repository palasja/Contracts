using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Threading.Tasks;

namespace Test.Services
{
    // Глобальное событие для запрета работы в системе блазор после выхода юзера из системы
    // на отдельной вкладке браузера.
    // Проблема описана здесь: https://github.com/dotnet/aspnetcore/issues/18901
    // выхода из аккаунта с другой вкладки браузера


    // Класс для отслеживания выхода текущего юзера из системы.
    public class TrackUserLogout
    {
        public delegate void UserLogoutEventHandler(string name);

        public event UserLogoutEventHandler UserOut;

        // Вызов события выхода юзера из системы.
        // Возбуждается в BookAppPKNET5\Areas\Identity\Pages\Account\LogOut.cshtml
        // Выполняется в BookAppPKNET5\Shared\MainLayout.razor
        public virtual void OnUserOut(string name) => UserOut?.Invoke(name);
    }
}
