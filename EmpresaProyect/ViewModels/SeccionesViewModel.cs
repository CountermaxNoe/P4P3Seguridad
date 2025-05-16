using EmpresaProyect.models;
using EmpresaProyect.Repositories;
using GalaSoft.MvvmLight.Command;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EmpresaProyect.ViewModels
{
    public class SeccionesViewModel : INotifyPropertyChanged
    {
        public SeccionesRepository repos = new SeccionesRepository();
        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand GuardarCommand { get; set; }
        public ICommand GuardarEliminarCommand {  get; set; }
        public ICommand CancelarCommand { get; set; }
        public ICommand VerAgregarSeccionesCommand {  get; set; }

        public ObservableCollection<Secciones> ListaSecciones { get; set; } = new();
        public string Modo { get; set; } = "Ver";

        public SeccionesViewModel()
        {
            GuardarCommand = new RelayCommand(Guardar);
            CancelarCommand = new RelayCommand(Cancelar);
            VerAgregarSeccionesCommand = new RelayCommand(VerAgregarSecciones);
            GuardarEliminarCommand = new RelayCommand(GuardarEliminar);
            CargarSecciones();
        }

        private void CargarSecciones()
        {
            foreach (var item in repos.GetAll())
            {
                ListaSecciones.Add(item);
            }
        }

        private void GuardarEliminar()
        {
            throw new NotImplementedException();
        }

        private void VerAgregarSecciones()
        {
            throw new NotImplementedException();
        }

        private void Cancelar()
        {
            throw new NotImplementedException();
        }

        private void Guardar()
        {
            throw new NotImplementedException();
        }
        public void Actualizar(string nombre)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
}
