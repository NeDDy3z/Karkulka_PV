using UnityEngine;

public class QuestionBuilder : MonoBehaviour
{
    public MapBuilder mapBuilder;

    public void MyStart()
    {
        mapBuilder.myQuestionList.Add(new Question("Jaká je váha atomu vodíku?", "1,00794 g/mol", "0.000000000796 kg", " 0.0079 g", false));
        mapBuilder.myQuestionList.Add(new Question("Kolik stojí párek v rohlíku ve školním bufáèi? (Listpoad 2022)", "30Kè", "40Kè", "35Kè", false));
        mapBuilder.myQuestionList.Add(new Question("Kolik váží prùmìrný 12 patrový panelák?", "Hodnì", "380 tun", "4000 kg", false));
        mapBuilder.myQuestionList.Add(new Question("Co si pamatuje prùmìrný žák naší tøídy z 1. a 2. roèníku elektrotechniky?", "Elektro-co?", "Aspoò základy", "Ví jak zapojit obvod", false));
        mapBuilder.myQuestionList.Add(new Question("Jaké rakety jsou kompatibilní s Mig-21", "R-60", "AIM-9P", "B777", false));
        mapBuilder.myQuestionList.Add(new Question("Vyberte správný \"based\" rok", "1984", "1969", "2001", false));
        mapBuilder.myQuestionList.Add(new Question("What's the deal with airline food?", "Like what is the deal with airline food.", "I don't understand the question and now Im scared of peanuts", "idk", false));
        mapBuilder.myQuestionList.Add(new Question("Jaký je pøíkaz na vytvoøení složky v BASH?", "mkdir", "createdir", "mkfolder", false));
        mapBuilder.myQuestionList.Add(new Question("Nástroj kterým se oøe pole", "Pluh", "Kultivátor", "Seèka", false));
        mapBuilder.myQuestionList.Add(new Question("Hlavní mìsto Švédska", "Stockholm", "Kodaò", "Oslo", false));
        mapBuilder.myQuestionList.Add(new Question("Jaké stíhaèky má právì pronajmuté AÈR (r.2022)?", "Gripen JAS-39", "Mig-35", "F-35", false));
        mapBuilder.myQuestionList.Add(new Question("Kdo namaloval obraz Persistence pamìti", "Salvador Dalí", "Salvador Gannachi", "Salvador Peralhí", false));
        mapBuilder.myQuestionList.Add(new Question("Co by mìla obsahovat každá správna cookie?", "Èokoládu", "Bombonky", "Duhový posyp", false));
        mapBuilder.myQuestionList.Add(new Question("Jaký je èeský státní svátek 17. listopadu?", "Den boje za svobodu a demokracii", "Den èeské státnosti", "Den konce 2. s.v.", false));
        mapBuilder.myQuestionList.Add(new Question("Vyber správnou možnost", "PC", "Playstation", "Xbox", false));
        mapBuilder.myQuestionList.Add(new Question("Jakému letounu bylo zakázáno vzletìt na rok a pùl kvùli svému nefunkènímu systému MCAS?", "B737-MAX", "A320neo", "AR-15", false));
        mapBuilder.myQuestionList.Add(new Question("Kdo napsal 1984?", "George Orwell", "Gorgor Well", "Greg Powell", false));
        mapBuilder.myQuestionList.Add(new Question("Na jakou barvu je lidské oko nejcitlivìjší?", "Zelenou", "Modrou", "Bílou", false));
        mapBuilder.myQuestionList.Add(new Question("Rok kdy se rozpadli The Beatles", "1970", "1969", "1984", false));
        mapBuilder.myQuestionList.Add(new Question("Kterému králi se pøezdívalo \"král železný a zlatý\"", "Pøemysl Otakar II.", "Václav III.", "František Josef IV.", false));
        mapBuilder.myQuestionList.Add(new Question("Jaká grafická karta pøedstavuje nebezpeèí požáru?", "RTX4090", "RX9090", "Arc10-190", false));
        mapBuilder.myQuestionList.Add(new Question("V jakém roce byl vydán Apple Computer 1", "1976", "1979", "1981", false));
        mapBuilder.myQuestionList.Add(new Question("Jaká kyselina nejlépe rozežere lidské tìlo?", "Kyselina sírová", "Kyselina arsenitá", "Kyselina fluorièná", false));
        mapBuilder.myQuestionList.Add(new Question("Jerma je jakože: ", "Sparkel on it's wednesday, don't forget to be yourself", "I have a big bussy", "Spongebob lol", false));
        mapBuilder.myQuestionList.Add(new Question("Kdy byl Adobe Flash kompletnì odstaven", "2020", "2021", "2017", false));
        mapBuilder.myQuestionList.Add(new Question("Doplò: Anime je...", "pro holky.", "fuj.", "super.", false));

        Debug.Log("QuestionBuilder - done.");
    }
}
