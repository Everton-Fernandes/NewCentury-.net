﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Exercicio_V
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            this.Jogo = new JogoAdivinhacao(0); //default é medio;
            this.DificuldadeETentativas = new Dictionary<string, int>();
            this.DificuldadeETentativas = Jogo.ObterDificuldadeETentativas();
            this.Tentativas = new List<int>();
            this.HistoricoList = new List<HistoricoTentativas>();
            foreach (var kv in DificuldadeETentativas)
            {
                switch (kv.Key.ToLower())
                {
                    case "fácil":
                        this.Facil = $"{kv.Key} - Tentativas: {kv.Value}";
                        break;
                    case "médio":
                        this.Medio = $"{kv.Key} - Tentativas: {kv.Value}";
                        break;
                    case "difícil":
                        this.Dificil = $"{kv.Key} - Tentativas: {kv.Value}";
                        break;
                }
                this.Tentativas.Add(kv.Value);
            }

            OnPropertyChanged(nameof(Jogo));
            OnPropertyChanged(nameof(DificuldadeETentativas));
            OnPropertyChanged(nameof(Valor));
            OnPropertyChanged(nameof(Rank));
            OnPropertyChanged(nameof(Facil));
            OnPropertyChanged(nameof(Medio));
            OnPropertyChanged(nameof(Dificil));
        }

        public JogoAdivinhacao Jogo { get; set; }

        public Dictionary<string, int> DificuldadeETentativas { get; set; }

        public List<int> Tentativas { get; set; }

        public List<HistoricoTentativas> HistoricoList { get; set; }

        public int Valor { get; set; } = 0;

        public int QuantJogo { get; set; } = 0;

        public float TaxaVitorias { get; set; } = 0;

        public int TaxaDerrota { get; set; } = 0;

        public int Jogador { get; set; }

        public int Count { get; set; } = 0;

        public string Rank { get; set; }

        public string Facil { get; set; }

        public string Medio { get; set; }

        public string Dificil { get; set; }

        public bool BoolPessoa { get; set; } = true;

        public bool BoolMaquina { get; set; } = true;

        public bool BoolFacil { get; set; } = true;

        public bool BoolMedio { get; set; } = true;

        public bool BoolDificil { get; set; } = true;

        private void BtnPessoa(object sender, EventArgs e)
        {
            Jogador = 1;

            if (BoolPessoa == true)
            {
                BoolPessoa = false;
                BoolMaquina = true;
                btnPessoa.BackgroundColor = Color.FromHex("#90989F");
                btnPessoa.TextColor = Color.FromHex("#FAFAFA");
                btnMaquina.BackgroundColor = Color.FromHex("#0B3B60");
                btnMaquina.TextColor = Color.FromHex("#DCDCDC");
            }
        }

        private void BtnMaquina(object sender, EventArgs e)
        {
            Jogador = 2;
            if (BoolMaquina == true)
            {
                BoolPessoa = true;
                BoolMaquina = false;
                btnMaquina.BackgroundColor = Color.FromHex("#90989F");
                btnMaquina.TextColor = Color.FromHex("#FAFAFA");
                btnPessoa.BackgroundColor = Color.FromHex("#0B3B60");
                btnPessoa.TextColor = Color.FromHex("#DCDCDC");
            }
        }

        private void BtnFacil(object sender, EventArgs e)
        {
            Jogo.TotalTentativas = Tentativas[0];
            Jogo.RestTentativas = Tentativas[0];
            Count = 0;
            QuantJogo++;

            if (BoolFacil == true)
            {
                BoolFacil = false;
                BoolMedio = true;
                BoolDificil = true;
                btnFacil.BackgroundColor = Color.FromHex("#90989F");
                btnFacil.TextColor = Color.FromHex("#FAFAFA");
                btnMedio.BackgroundColor = Color.FromHex("#0B3B60");
                btnMedio.TextColor = Color.FromHex("#DCDCDC");
                btnDificil.BackgroundColor = Color.FromHex("#0B3B60");
                btnDificil.TextColor = Color.FromHex("#DCDCDC");
            }
        }

        private void BtnMedio(object sender, EventArgs e)
        {
            Jogo.TotalTentativas = Tentativas[1];
            Jogo.RestTentativas = Tentativas[1];
            Count = 0;
            QuantJogo++;

            if (BoolMedio == true)
            {
                BoolFacil = true;
                BoolMedio = false;
                BoolDificil = true;
                btnFacil.BackgroundColor = Color.FromHex("#0B3B60");
                btnFacil.TextColor = Color.FromHex("#DCDCDC");
                btnMedio.BackgroundColor = Color.FromHex("#90989F");
                btnMedio.TextColor = Color.FromHex("#FAFAFA");
                btnDificil.BackgroundColor = Color.FromHex("#0B3B60");
                btnDificil.TextColor = Color.FromHex("#DCDCDC");
            }
        }

        private void BtnDificil(object sender, EventArgs e)
        {
            Jogo.TotalTentativas = Tentativas[2];
            Jogo.RestTentativas = Tentativas[2];
            Count = 0;
            QuantJogo++;

            if (BoolDificil == true)
            {
                BoolFacil = true;
                BoolMedio = true;
                BoolDificil = false;
                btnFacil.BackgroundColor = Color.FromHex("#0B3B60");
                btnFacil.TextColor = Color.FromHex("#DCDCDC");
                btnMedio.BackgroundColor = Color.FromHex("#0B3B60");
                btnMedio.TextColor = Color.FromHex("#DCDCDC");
                btnDificil.BackgroundColor = Color.FromHex("#90989F");
                btnDificil.TextColor = Color.FromHex("#FAFAFA");
            }
        }

        private void CarregarLista()
        {
            HistoricoList.Add(Jogo.historicoTentativas.FirstOrDefault());
            historicoList.ItemsSource = HistoricoList;
            OnPropertyChanged(nameof(HistoricoList));
        }

        private void BtnEnviar(object sender, EventArgs e)
        {
            string escolhaDificuldade = "Médio"; // Default

            if (BoolFacil == false)
                escolhaDificuldade = "Fácil";
            else if (BoolMedio == false)
                escolhaDificuldade = "Médio";
            else if (BoolDificil == false)
                escolhaDificuldade = "Difícil";

            if (DificuldadeETentativas.TryGetValue(escolhaDificuldade, out int tentativas))
            {
                Jogo.Jogar(Jogador, Valor); // Jogador humano

                if (Jogo.historicoTentativas.Count != 0)
                {
                    CarregarLista();

                    Count++;
                }
                TaxaVitorias = (Jogo.TotalVitorias * 100) / QuantJogo;
                TaxaDerrota = Jogo.TotalDerrotas;
                OnPropertyChanged(nameof(TaxaDerrota));
                OnPropertyChanged(nameof(TaxaVitorias));
                switch (TaxaVitorias)
                {
                    case float i when i < 20.0f:
                        Rank = "E";
                        OnPropertyChanged(nameof(Rank));
                        break;
                    case float i when i < 40.0f:
                        Rank = "D";
                        OnPropertyChanged(nameof(Rank));
                        break;
                    case float i when i < 60.0f:
                        Rank = "C";
                        OnPropertyChanged(nameof(Rank));
                        break;
                    case float i when i < 80.0f:
                        Rank = "B";
                        OnPropertyChanged(nameof(Rank));
                        break;
                    case float i when i < 99.0f:
                        Rank = "A";
                        OnPropertyChanged(nameof(Rank));
                        break;
                    case float i when i == 100.0f:
                        Rank = "S";
                        OnPropertyChanged(nameof(Rank));
                        break;
                    default:
                        break;
                }
                DisplayAlert("Alert", $"{Jogo.Menssagen}", "OK");
            }
            else
            {
                DisplayAlert("Alert", "Opção de dificuldade inválida.", "OK");
            }
        }
    }
}
