using Avalonia.Media;
using Avalonia;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using CursWorkAvalonia.Models;
using System.Collections.Specialized;
using TreeDataGridDemo.ModelDogs;


namespace CursWorkAvalonia.ViewModels
{

    public class MainWindowViewModel : ViewModelBase
    {
        private Request _request;
        public Request SelectedRequest
        {
            get => _request;
            set => this.RaiseAndSetIfChanged(ref _request,value);
        }

        private ObservableCollection<Dog> _Dogs;
        private ObservableCollection<Stat> _Stats;
        private ObservableCollection<Match> _Matches;
        private ObservableCollection<Result> _Results;
        private ObservableCollection<Track> _Tracks;





        public ObservableCollection<Dog> Dogs
        {
            get => _Dogs;
            set => this.RaiseAndSetIfChanged(ref _Dogs, value);
        }
        public ObservableCollection<Stat> Stats
        {
            get => _Stats;
            set => this.RaiseAndSetIfChanged(ref _Stats, value);
        }
        public ObservableCollection<Match> Matches
        {
            get => _Matches;
            set => this.RaiseAndSetIfChanged(ref _Matches, value);
        }
        public ObservableCollection<Result> Results
        {
            get => _Results;
            set => this.RaiseAndSetIfChanged(ref _Results, value);
        }
        public ObservableCollection<Track> Tracks
        {
            get => _Tracks;
            set => this.RaiseAndSetIfChanged(ref _Tracks, value);
        }
        
        private ObservableCollection<Request> _requests;
        public ObservableCollection<Request> Requests
        {
            get => _requests;
            set => this.RaiseAndSetIfChanged(ref _requests, value);
        }
        private ViewModelBase _content;
        public ViewModelBase Content
        {
            get => _content;
            set => this.RaiseAndSetIfChanged(ref _content, value);
        }
        
        public MainWindowViewModel()
        {

            using(var db = new dogs_raceContext())
            {
                this.Dogs = new ObservableCollection<Dog>(db.Dogs);
                this.Results = new ObservableCollection<Result>(db.Results);
                this.Stats = new ObservableCollection<Stat>(db.Stats);
                this.Matches = new ObservableCollection<Match>(db.Matches);
                this.Tracks = new ObservableCollection<Track>(db.Tracks);
            }
            Content = new DataBaseViewModel();
            Requests = new ObservableCollection<Request>()
            {
                new Request("1"),
                new Request("2")
            };

          
        }
        public void CreateRequest()
        {
            Requests.Add(new Request("New request"));
        }
        public void DeleteRequest(Request e)
        {
            Requests.Remove(e);
        }

        public void DeleteDog(Dog e) => Dogs.Remove(e);
        public void DeleteStat(Stat e) => Stats.Remove(e);
        public void DeleteResult(Result e) => Results.Remove(e);
        public void DeleteMatch(Match e) => Matches.Remove(e);
        public void DeleteTrack(Track e) => Tracks.Remove(e);

        public void CreateDog() => Dogs.Add(new Dog() {Dogid = 1 , Name = "new" , Gender = "new" , Stats = 1 });
        public void CreateStat() => Stats.Add(new Stat() { Statsid = 1 , Wins = 1 , Races = 1 ,  Windist = 1 });
        public void CreateResult() => Results.Add(new Result() { Resultsid = 1 , Winner = 1 , Reward = 1 });
        public void CreateMatch() => Matches.Add(new Match() { Matchesid = 1, Results = 1 , Year = 1 , Grand = "new" });
        public void CreateTrack() => Tracks.Add(new Track() { Trackid = 1 , Dist = 1 , City = "new"});
     
        public void SQLRequestOpen() => Content = new SQLRequestViewModel();
        public void SQLRequestRun()
        {
            
            using(var db = new dogs_raceContext())
            {
               //Сделать реализацию запросов, через свитч команды(SELECT JOIN и т.д.), в кейсах сам запрос, результат записывать в список запросов
               // Тип списка запросов? Отдельный класс?
            }
            Content = new DataBaseViewModel();
        }
    }
}
