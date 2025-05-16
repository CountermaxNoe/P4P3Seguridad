using GalaSoft.MvvmLight.Command;
using P4P3Seguridad.Helpers;
using P4P3Seguridad.models;
using P4P3Seguridad.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace P4P3Seguridad.ViewModels
{
    public enum Vistas { Login, Registrar, Principal }
    public class UsuariosViewModel : INotifyPropertyChanged
    {
        UsuariosRepository repos = new();
        HelpCorreo helper = new();

        public Usuarios Usuario { get; set; }
        public Usuarios UsuarioEnSecion { get; set; }
        public UsuarioLogin UsuarioLogin { get; set; }
        public Vistas Vista { get; set; }= Vistas.Login;
        public ICommand LoginCommand { get; set; }
        public ICommand VerLoginCommand { get; set; }
        public ICommand VerRegistrarCommand { get; set; }
        public ICommand RegistrarCommand { get; set; }
        public ICommand CancelarCommand { get; set; }

        public string? Error
        {
            get { return error; }
            set { error = value;}
        }
        public ObservableCollection<Usuarios> ListaUsuarios { get; set; } = new();
        public string? error;

        public UsuariosViewModel()
        {
            LoginCommand = new RelayCommand(Login);
            VerLoginCommand = new RelayCommand(VerLogin);
            VerRegistrarCommand = new RelayCommand(VerRegistrar);
            RegistrarCommand = new RelayCommand(Registrar);
            CancelarCommand = new RelayCommand(Cancelar);
            Vista=Vistas.Login;
            UsuarioLogin = new UsuarioLogin();
            Actualizar(nameof(UsuarioLogin));
        }

        private void VerLogin()
        {
            Vista = Vistas.Login;
            Actualizar(nameof(Vista));
            UsuarioLogin = new UsuarioLogin();
            Actualizar(nameof(UsuarioLogin));
        }

        private void Cancelar()
        {
            Vista = Vistas.Login;
            Actualizar(nameof(Vista));
        }

        private void Registrar()
        {
            if (!repos.Validar(Usuario, out error))
            {
                Vista = Vistas.Principal;
                Actualizar(nameof(Vista));
                helper.SendMail(Usuario.Correo, "Registrar usuario", "Sistema de control escolar" +
    " te da la bienvenida al registro del sistema //Noe Gomez");
                repos.Insert(Usuario);
            }
            else
            {
                Error = error;
                Actualizar(nameof(Error));
            }
        }

        private void VerRegistrar()
        {
            Error = "";
            error = "";
            Actualizar(nameof(error));
            Actualizar(nameof(Error));
            Vista = Vistas.Registrar;
            Usuario = new Usuarios();
            Actualizar(nameof(Usuario));
            Actualizar(nameof(Vista));
        }

        private void Login()
        {
            Error = "";
            error = "";
            Actualizar(nameof(error));
            Actualizar(nameof(Error));

            int result = repos.Login(UsuarioLogin);
            Actualizar(nameof(UsuarioLogin));

            if (result == 0)
            {
                Error += "El correo no existe";
            }
            if (result == 1)
            {
                Error += "La contraseña es incorrecta";
            }
            if (result == 2)
            {
                Vista = Vistas.Principal;
                Actualizar(nameof(Vista));
                UsuarioEnSecion = repos.Secion(UsuarioLogin.Correo);
                Actualizar(nameof(UsuarioEnSecion));
            }
            Actualizar(nameof(Error));
        }

        public void Actualizar(string nombre)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
