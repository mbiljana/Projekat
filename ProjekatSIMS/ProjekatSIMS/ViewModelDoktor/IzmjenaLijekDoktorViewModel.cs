﻿using Controller;
using Model;
using Newtonsoft.Json;
using ProjekatSIMS.Commands;
using ProjekatSIMS.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows.Navigation;

namespace ProjekatSIMS.ViewModelDoktor
{
    public class IzmjenaLijekDoktorViewModel : BindableBase
    {
        private NavigationService navService;
        private Lijek izabraniLijek;
        private String opis;
        private String naziv;
        private String noviSastojak;
        public Lijek alternativniLijek;

        private LijekRepository lijekRepository = new LijekRepository();
        private IzmjenaLijekaDoktorController izmjenaLijekaController = new IzmjenaLijekaDoktorController();
        private CuvanjeIzmjenaLijekaDoktorController cuvanjeIzmjenaLijekaDoktorController = new CuvanjeIzmjenaLijekaDoktorController();
        public ObservableCollection<Lijek> SviLijekovi { get; set; }
        public ObservableCollection<StringWrapper> Sastojci { get; set; }
        public ObservableCollection<StringWrapper> AlternativniLijekovi { get; set; }

        private RelayCommand dodajSastojak;
        private RelayCommand dodajALternativniLijek;
        private RelayCommand sacuvaj;
        private RelayCommand odustani;

        public RelayCommand DodajSastojak
        {
            get { return dodajSastojak; }
            set
            {
                dodajSastojak = value;
            }
        }

        public RelayCommand Odustani
        {
            get { return odustani; }
            set
            {
                odustani = value;
            }
        }

        public RelayCommand Sacuvaj
        {
            get { return sacuvaj; }
            set
            {
                sacuvaj = value;
            }
        }
        public RelayCommand DodajAlternativniLijek
        {
            get { return dodajALternativniLijek; }
            set
            {
                dodajALternativniLijek = value;
            }
        }

        public string NoviSastojak
        {
            get { return noviSastojak; }
            set
            {
                if (noviSastojak != value)
                {
                    noviSastojak = value;
                    OnPropertyChanged("NoviSastojak");
                    //DodajSastojak.RaiseCanExecuteChanged();
                }
            }
        }
        public Lijek AlternativniLijek
        {
            get { return alternativniLijek; }
            set
            {
                if (alternativniLijek != value)
                {
                    alternativniLijek = value;

                    DodajAlternativniLijek.RaiseCanExecuteChanged();
                }
            }
        }

        public string Opis
        {
            get { return opis; }
            set
            {
                if (opis != value)
                {
                    opis = value;
                    OnPropertyChanged("Opis");
                }
            }
        }
        public string Naziv
        {
            get { return naziv; }
            set
            {
                if (naziv != value)
                {
                    naziv = value;
                    OnPropertyChanged("Naziv");
                }
            }
        }

        public Lijek IzabraniLijek
        {
            get { return izabraniLijek; }
            set
            {
                izabraniLijek = value;

            }
        }
        public NavigationService NavService
        {
            get { return navService; }
            set
            {
                navService = value;
            }
        }

        public void Ucitaj(Lijek izabraniLijek)
        {
            Sastojci = new ObservableCollection<StringWrapper>();
            AlternativniLijekovi = new ObservableCollection<StringWrapper>();
            Naziv=izabraniLijek.NazivLeka;
            Opis = izabraniLijek.Opis;
            foreach(String l in izabraniLijek.Alergeni)
            {
                StringWrapper s = new StringWrapper();
                s.Text = l;
                Sastojci.Add(s);
            }
            foreach (String a in izabraniLijek.AlternativniLekovi)
            {
                StringWrapper s = new StringWrapper();
                s.Text = a;
                AlternativniLijekovi.Add(s);
            }
            List<Lijek> lijekovi = lijekRepository.DobaviSve();
            SviLijekovi = new ObservableCollection<Lijek>(lijekovi);

        }

        public void Executed_DodajSastojak()
        {

            if (IzabraniLijek.Alergeni == null)
                IzabraniLijek.Alergeni = new List<String>();
            IzabraniLijek.Alergeni.Add(NoviSastojak);

            StringWrapper sw = new StringWrapper();
            sw.Text = NoviSastojak;
            Sastojci.Add(sw);

        }
        public bool CanExecute_DodajSastojak()
        {
            // return (NoviSastojak!=null);
            return true;

        }

        public void Executed_DodajAlternativniLijek()
        {

           // IzabraniLijek.AlternativniLekovi = izmjenaLijekaController.DodavanjeALternativnihLijekova(IzabraniLijek.NazivLeka, IzabraniLijek);
            if (IzabraniLijek.AlternativniLekovi == null)
                IzabraniLijek.AlternativniLekovi = new List<String>();
            IzabraniLijek.AlternativniLekovi.Add(AlternativniLijek.NazivLeka);
           
            StringWrapper sw = new StringWrapper();
            sw.Text = AlternativniLijek.NazivLeka;
            AlternativniLijekovi.Add(sw);
        }

        public bool CanExecute_DodajAlternativniLijek()
        {

            return AlternativniLijek != null;
        }

        public void Executed_Sacuvaj()
        {
            Lijek l = new Lijek();
            l.NazivLeka = Naziv;
            l.Opis = Opis;
            l.Status = IzabraniLijek.Status;

            cuvanjeIzmjenaLijekaDoktorController.SacuvajIzmjene(l, Sastojci, AlternativniLijekovi);
            this.NavService.GoBack();

          
        }

        public void Executed_Odustani()
        {
            this.NavService.GoBack();
        }
        public IzmjenaLijekDoktorViewModel(NavigationService service, Lijek lijek)
        {
            this.navService = service;
            this.izabraniLijek = lijek;
            Ucitaj(lijek);
            this.DodajSastojak = new RelayCommand(Executed_DodajSastojak, CanExecute_DodajSastojak);
            this.DodajAlternativniLijek = new RelayCommand(Executed_DodajAlternativniLijek, CanExecute_DodajAlternativniLijek);
            this.Sacuvaj = new RelayCommand(Executed_Sacuvaj);
            this.Odustani = new RelayCommand(Executed_Odustani);
        }
    }
}
