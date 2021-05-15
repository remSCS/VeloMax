﻿using ApplicationVeloMax.Models;
using ApplicationVeloMax.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ApplicationVeloMax.Views.Modeles
{
    /// <summary>
    /// Interaction logic for EditModeleView.xaml
    /// </summary>
    public partial class EditModeleView : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Modele _selectedModele;
        public Modele SelectedModele
        {
            get { return _selectedModele; }
            set
            {
                _selectedModele = value;
                dateETb.DisplayDateEnd = DateTime.Today;
                dateSTb.DisplayDateStart = SelectedModele.DateE;
                dateSTb.DisplayDateEnd = DateTime.Today;
                PropertyChanged(this, new PropertyChangedEventArgs("SelectedModele"));
            }
        }

        private ObservableCollection<Grandeur> _grandeurs;
        public ObservableCollection<Grandeur> Grandeurs
        {
            get { return _grandeurs; }
            set
            {
                _grandeurs = value; 
                PropertyChanged(this, new PropertyChangedEventArgs("Grandeurs"));
            }
        }

        private ObservableCollection<LigneProduit> _lignesProduits;
        public ObservableCollection<LigneProduit> LignesProduits
        {
            get { return _lignesProduits; }
            set { _lignesProduits = value; 
                PropertyChanged(this, new PropertyChangedEventArgs("LignesProduits")); }
        }


        public EditModeleView(Modele _input)
        {
            InitializeComponent();
            SelectedModele = _input;
            Grandeurs = new ObservableCollection<Grandeur>(Grandeur.Ensemble);
            LignesProduits = new ObservableCollection<LigneProduit>(LigneProduit.Ensemble);
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            int id = SelectedModele.Id;
            string nom = SelectedModele.Nom;
            Grandeur grandeur = SelectedModele.GrandeurModele;
            decimal prix = SelectedModele.PrixUnitaire;
            LigneProduit ligne = SelectedModele.LigneProduitModele;
            DateTime de = SelectedModele.DateE;
            DateTime ds = SelectedModele.DateS;

            try
            {
                nom = nomTb.Text;
                grandeur = (Grandeur)grandeurTb.SelectedItem;
                prix = Convert.ToDecimal(prixTb.Text);
                ligne = (LigneProduit)ligneTb.SelectedItem;
                de = DateTime.Parse(dateETb.Text);
                ds = DateTime.Parse(dateSTb.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veuillez vérifier le format !\nErreur : " + ex.ToString());
                return;
            }

            if (!DataAccess.FullyEditModele(id, nom, grandeur, prix, ligne, de, ds)) MessageBox.Show("Modification impossible.");

            else
            {
                MessageBox.Show("Modifications effectuées");
                this.Close();
            }
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e) => this.Close();
    }
}