using EmpresaProyect.models;
using EmpresaProyect.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace EmpresaProyect.ViewModels
{
    public class InicioViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public UserControl Vista { get; set; } = new UserControl();
        public SeccionesView vistasecciones = new();
        public EstadisticasView vistaestadisticas = new();
        public ReportesView vistareportes = new();
        public EmpleadosView vistaempleados= new();
        public ICommand IniciarCommand { get; set; }
        public ICommand AdmnistrarEmpleadosCommand { get; set; }
        public ICommand AdministrarSeccionesCommand {  get; set; }
        public ICommand ReportesCommand {  get; set; }

        public InicioViewModel()
        {
            IniciarCommand = new RelayCommand(Iniciar);
            AdministrarSeccionesCommand = new RelayCommand(AdministrarSecciones);
            AdmnistrarEmpleadosCommand = new RelayCommand(AdministrarEmpleados);
            ReportesCommand = new RelayCommand(Reportes);
            Vista = vistaestadisticas;
        }

        private void Reportes()
        {
            Vista = vistareportes;
            Actualizar(nameof(vistareportes));
        }

        private void AdministrarEmpleados()
        {
            Vista = vistaempleados;
            Actualizar(nameof(vistaempleados));
        }

        private void AdministrarSecciones()
        {
            Vista = vistasecciones;
            Actualizar(nameof(vistareportes));
        }

        private void Iniciar()
        {
            throw new NotImplementedException();
        }

        public void Actualizar(string nombre)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }
}
