using LAB_1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace LAB_1.Services
{
    public class SalonServices
    {
        //Создадим список для хранения данных из источника
        List<Salon> salonList = new();
        // Метод GetSalon() служит для извлечения и сруктурирования данных
        // в соответсвии с существующей моделью данных
        public async Task<IEnumerable<Salon>>GetSalon()
        {
            // Если список содержит какие-то элементы
            // то вернется последовательность с содержимым этого списка
            if (salonList?.Count > 0)
                return salonList;

            // В данном блоке кода осуществляется подключение, чтение
            // и дессериализация файла - источника данных
            using var stream = await FileSystem.OpenAppPackageFileAsync("food.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            salonList = JsonSerializer.Deserialize<List<Salon>>(contents);

            return salonList;
        }
    }
}

