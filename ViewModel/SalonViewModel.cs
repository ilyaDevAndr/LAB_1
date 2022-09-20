using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB_1.Model;
using LAB_1.Services;
using System.Collections.ObjectModel;


namespace LAB_1.ViewModel
{
    public class SalonViewModel
    {
        // Переменная для хранения состояния
        // выбранного элемента коллекции
        private Salon _selecteditem;

        // Объект с логикой по извлечению данных
        // из источника
        SalonServices salonServices = new();
        // Коллекция извлекаемых объектов
        public ObservableCollection<Salon> Salons { get; set; }
        // Конструктор с вызовом метода
        // получения данных
        public SalonViewModel()
        {
            GetSalonsAsync();
        }

        // Публичное свойство для представления
        // описания выбранного элемента из коллекции
        public string Desc { get; set; }

        // Свойство для представления и изменения
        // состояния выбранного объекта
        public Salon SelectedItem
        {
            get => _selecteditem;
            set
            {
                _selecteditem = value;
                Desc = value?.Description;
                // Метод отвечает за обновление данных
                // в реальном времени
                OnPropertyChanged(nameof(Desc));
            }
        }
        // Метод получения коллекции объектов
        async Task GetSalonsAsync()
        {
            try
            {
                var salons = await salonServices.GetSalon();
                if (Salons.Count!= 0)
                    Salons.Clear();
                foreach (var salon in salons)
                {
                    Salons.Add(salon);  
                }    

            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Ошибка!",
                    $"Что-то пошло не так:{ex.Message}", "ok");
            }
        }
    }
}
