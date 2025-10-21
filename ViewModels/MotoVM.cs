using MotoAPP.Models;
using MotoAPP.Services;
using MotoAPP.Views;
using System.Security.Cryptography.X509Certificates;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MotoAPP.ViewModels
{
    public class MotoVM : BaseVM
    {

        MotoService motoservice = new MotoService();

        // VARIAVEIS
        private string _descricao;
        private string _marca;
        private string _modelo;
        private string _ano;
        private ObservableCollection<Moto> _motos;
        // COMANDOS

        public ICommand CommandVoltar { get; set; }
        public ICommand CommandCadastrar { get; set; }
        public ICommand CommandMotoView { get; set; }
        public ICommand CommandVisualizar { get; set; }
        public ICommand CommandVisMotoView { get; set; }

        // PROPRIEDADES

        public string Descricao
        {
            get { return _descricao; }
            set
            {
                _descricao = value;
                OnPropertyChanged();
            }

        }
        public string Marca
        {
            get { return _marca; }
            set
            {
                _marca = value;
                OnPropertyChanged();
            }

        }
        
        public string Modelo
        {
            get { return _modelo; }
            set
            {
                _modelo = value;
                OnPropertyChanged();
            }

        }
        public string Ano
        {
            get { return _ano; }
            set
            {
                _ano = value;
                OnPropertyChanged();
            }

        }
        public ObservableCollection<Moto> Motos
        {
            get { return _motos; }
            set
            {
                _motos = value;
                OnPropertyChanged();
            }
        }

        // METODOS
        void CadastrarMoto()
        {
            if (string.IsNullOrWhiteSpace(Descricao) ||
                string.IsNullOrWhiteSpace(Marca) ||
                string.IsNullOrEmpty(Modelo) ||
                string.IsNullOrEmpty(Ano))
            {
                AvisoTela("Por favor, preencha todos os campos");
                return;
            }

            Moto moto = new Moto();

            moto.Descricao = Descricao;
            moto.Marca = Marca;
            moto.Modelo = Modelo;
            moto.Ano = Ano;

            motoservice.Insert(moto);

            InfTela("Moto Cadastrada com sucesso!😎");
            AbrirView(new VisMotoView());
        }

        //void VisMoto()
        //{
        //    Moto moto = new Moto();

        //    Descricao = moto.Descricao;
        //    Marca = moto.Marca;
        //    Modelo = moto.Modelo;
        //    Ano = moto.Ano;

        //    motoservice.GetAll();
        //}

        void VisMoto()
        {
            // 1. Chama o método GetAll do Service
            List<Moto> listaDoDB = motoservice.GetAll();

            // 2. Converte a lista para ObservableCollection
            Motos = new ObservableCollection<Moto>(listaDoDB);
        }

        void Voltar()
        {
            Voltar();
        }
        void MotoView()
        {
            AbrirView(new VisMotoView());
        }

        void MotoVisView()
        {
            AbrirView(new VisMotoView());
        }

        // CONSTRUTOR

        public MotoVM()
        {
            CommandCadastrar = new Command(CadastrarMoto);
            CommandVoltar = new Command(Voltar);
            CommandMotoView = new Command(MotoView);
            CommandVisualizar = new Command(VisMoto);
            CommandVisMotoView = new Command(MotoView);
        }
    }
}
