﻿using Model;
using ProjekatSIMS.Model;
using ProjekatSIMS.Repository;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjekatSIMS.Service
{
    public class OcenjivanjeLekaraService
    {
        public OcenaRepository ocenaRepositoryLekar = new OcenaRepository(@"..\..\..\Fajlovi\OcenaLekara.txt");
        public PregledRepository pregledRepository = new PregledRepository(@"..\..\..\Fajlovi\Pregled.txt");
        public bool lekarSeMozeOceniti = false;
        private Boolean DaLiSeLekarMozeOceniti(String ime, String prezime)
        {
            bool mozeSeOceniti = false;
            List<Pregled> pregledi = pregledRepository.DobaviSvePregledePacijent();
            foreach (Pregled p in pregledi)
            {
                if ((p.doktor.Ime == ime) && (p.doktor.Prezime == prezime))
                {
                    mozeSeOceniti = true;
                    break;
                }
            }
            return mozeSeOceniti;
        }

        private OcenaLekara PostavljanjeOceneLekara(String imeLekara, String prezimeLekara, String ocena, String komentar)
        {
            OcenaLekara ol = new OcenaLekara { ImeLekara = imeLekara, PrezimeLekara = prezimeLekara, Ocena = ocena, Komentar = komentar };
            return ol;
        }

        private Boolean DaLiPostojiZavrsenPregled()
        {
            List<Pregled> pregledi = pregledRepository.DobaviSvePregledePacijent();
            foreach (Pregled p in pregledi)
            {
                if ((p.StatusPregleda == StatusPregleda.Zavrsen))
                {
                    return true;
                }
            }
            return false;
        }

        public Boolean OcenjivanjeLekara(String imeLekara, String prezimeLekara, String ocena, String komentar)
        {
            List<OcenaLekara> oceneLekara = ocenaRepositoryLekar.DobaviSveOceneLekara();
            if (ocena != null)
            {
                if ((DaLiSeLekarMozeOceniti(imeLekara, prezimeLekara) == true) && (DaLiPostojiZavrsenPregled() == true))
                {
                    oceneLekara.Add(PostavljanjeOceneLekara(imeLekara, prezimeLekara, ocena, komentar));
                    ocenaRepositoryLekar.SacuvajOcenuLekara(oceneLekara);
                    return true;

                }
                return false;
            }
            else
            {
                return false;
            }
        }
        public Boolean DaLiJeUnetaOcena(String imeLekara, String prezimeLekara,String ocena,String komentar)
        {
            List<OcenaLekara> oceneLekara = ocenaRepositoryLekar.DobaviSveOceneLekara();
            if ((DaLiSeLekarMozeOceniti(imeLekara, prezimeLekara) == true) && (DaLiPostojiZavrsenPregled() == true))
            {
                oceneLekara.Add(PostavljanjeOceneLekara(imeLekara, prezimeLekara, ocena, komentar));
                ocenaRepositoryLekar.SacuvajOcenuLekara(oceneLekara);
                return true;

            }
            return false;
        }
    }
}