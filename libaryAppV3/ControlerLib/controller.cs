
using Microsoft.EntityFrameworkCore;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using repostory;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ClassesLib
{
    public class controller : INotifyPropertyChanged
    {
        private static controller instance;
        private static readonly object lockObject = new object();
        model Model = new model();
        hashing hash = new hashing();
        public delegate bool UserConfirmationDelegate(string message);
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<bool> LoginStatusChanged;
        public UserConfirmationDelegate ConfirmCallback { get; set; }
        private void OnLoginStatusChanged(bool isLoggedIn)
        {
            LoginStatusChanged?.Invoke(this, isLoggedIn);
        }
        private controller()
        {
            temp.Instance.UserChanged += Temp_UserChanged;
            // Private constructor to prevent instantiation.
        }
        private void Temp_UserChanged(object sender, EventArgs e)
        {
          
            LoadUserLendings();
        }
        private void LoadUserLendings()
        {
          
            if (temp.Instance.user != null)
            {
               
                UserLendings = new ObservableCollection<lendings>(
                    Model.Lendings.Where(l => l.User.Id == temp.Instance.user.Id)
                );
            }
        }
        public static controller Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObject)
                    {
                        if (instance == null)
                        {
                            instance = new controller();
                        }
                    }
                }
                return instance;
            }
        }
        public static void ResetInstanceForTest()
        {
            lock (lockObject)
            {
                instance = null;
            }
        }
        private ObservableCollection<object> selectedData;
        private PlotModel _graphModel;
        public PlotModel GraphModel
        {
            get { return _graphModel; }
            set
            {
                _graphModel = value;
                OnPropertyChanged(nameof(GraphModel));
            }
        }
        public ObservableCollection<object> SelectedData
        {
            get { return selectedData; }
            set
            {
                if (selectedData != value)
                {
                    selectedData = value;
                    OnPropertyChanged(nameof(SelectedData));
                }
            }
        }
        private ObservableCollection<lendings> userLendings;
        public ObservableCollection<lendings> UserLendings
        {
            get
            {
                return userLendings;
            }
            set
            {
                if (userLendings != value)
                {
                    userLendings = value;
                    OnPropertyChanged(nameof(UserLendings));
                }
            }
        }

        public ObservableCollection<roles> Roles
        {
            get
            {
                return Model.Roles.Local.ToObservableCollection();
            }
        }
        public ObservableCollection<users> Users
        {
            get
            {
                return Model.Users.Local.ToObservableCollection();
            }
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private ObservableCollection<DateTime> blackoutDates = new ObservableCollection<DateTime>();
        public ObservableCollection<DateTime> BlackoutDates
        {
            get { return blackoutDates; }
            set
            {
                blackoutDates = value;
                OnPropertyChanged(nameof(BlackoutDates));
            }
        }



        public ObservableCollection<bookss> Books
        {
            get
            {
                return Model.Books.Local.ToObservableCollection();
            }
        }
        public ObservableCollection<lendings> Lendings
        {
            get
            {
                return Model.Lendings.Local.ToObservableCollection();
            }
        }

        public ObservableCollection<lendingToUser> LendingToUsers
        {
            get
            {
                return Model.LendingToUsers.Local.ToObservableCollection();
            }
        }
        public void init()
        {
            Model.Users.Load();
            Model.Lendings.Load();
            Model.LendingToUsers.Load();
            Model.Books.Load();
            LoadUserLendings();
         
        }
        public users LoginUser(int login, string password)
        {
          
                users user = Model.Users
                    .FirstOrDefault(u => u.UsernameId == login);

                if (user != null)
                {
                // compare the hashed password
                    bool passwordMatch = hash.comparePassword(password, user.Password);

                    if (passwordMatch)
                    {
                        return user;
                    }
                }

                return null;
            
        }
        public bool CheckAdmin(int userId)
        {
            var user = Model.Users
                .Include(u => u.Role) 
                .FirstOrDefault(u => u.Id == userId);

            if (user != null && user.Role != null && user.Role.Role == "admin")
            {
                return true;
            }

            return false;
        }
        public void logout()
        {
            temp.name = 0;
            temp.UserId = 0;
        }
 
        public bool TryLogin(int login, string password)
        {
            users loggedinUser = LoginUser(login, password);

            if (loggedinUser != null)
            {
                bool isAdmin = CheckAdmin(loggedinUser.Id);
                temp.UserId = loggedinUser.Id;
                temp.name = loggedinUser.UsernameId;
                temp.Instance.user = loggedinUser;
                OnLoginStatusChanged(isAdmin);
                if (isAdmin)
                {
              

                    return true;
                }
                else
                {
       
                    return true;
                }
            }
            else
            {

                return false;
            }
        }
        public void UpdateBlackoutDates(bookss selectedBook, int userId)
        {
            var lendingDates = Model.Lendings
                .Where(l => l.Book == selectedBook && l.User.Id == userId)
                .Select(l => l.Date)
                .ToList();

            if (lendingDates != null && lendingDates.Count > 0)
            {
                BlackoutDates.Clear();
                foreach (var lendingDate in lendingDates)
                {
                    var endDate = lendingDate.AddDays(30);
                    for (var currentDate = lendingDate; currentDate <= endDate; currentDate = currentDate.AddDays(1))
                    {
                        BlackoutDates.Add(currentDate);
                    }
                }
            }
            else
            {
                BlackoutDates.Clear();
            }
        }
        public void updateBook(bookss book, string author, string title, string publisher, DateTime year, int count, int ISBN)
        {
            var existingBook = Model.Books.FirstOrDefault(t => t.Id == book.Id);

            if (existingBook != null)
            {
                existingBook.Author = author;
                existingBook.Title = title;
                existingBook.Publisher = publisher;
                existingBook.Year = year;
                existingBook.Count = count;
                existingBook.ISBN = ISBN;
                Model.SaveChanges();

            }
        }

        public void addBooks(bookss newbook)
        {
            Model.Books.Add(newbook);
            Model.SaveChanges();
        }
        public void deleteBook(bookss selectedbook)
        {
            var lendingToUsersToDelete = Model.LendingToUsers
                .Where(ltu => ltu.BookLendt.Book == selectedbook)
                .ToList();

            foreach (var ltu in lendingToUsersToDelete)
            {
                Model.LendingToUsers.Remove(ltu);
            }

            var lendingsToDelete = Model.Lendings
                .Where(lending => lending.Book == selectedbook)
                .ToList();

            foreach (var lending in lendingsToDelete)
            {
                Model.Lendings.Remove(lending);
            }

            Model.Books.Remove(selectedbook);
            Model.SaveChanges();
        }
        public bool IsLendingPast30Days(lendings lending)
        {
            DateTime currentDate = DateTime.Now;
            TimeSpan difference = currentDate - lending.Date;
            return difference.TotalDays > 30;
        }
        public bool CanUserLendBooks(int userID)
        {

            var lastLending = Model.Lendings
                .Where(ltu => ltu.User.Id == userID)
                .OrderByDescending(ltu => ltu.Date)
                .Select(ltu => ltu.Date)
                .ToList();

            if (lastLending.Any())
            {
                DateTime currentDate = DateTime.Now;
                foreach (DateTime last in lastLending)
                {
                    TimeSpan timeSinceLending = currentDate - last;

                    // if the users has lendings that is past or equla to 30 days
                    if (timeSinceLending.TotalDays > 30)
                    {
                        return false;
                    }
                }
            
            }
            // else true
            return true;
        }
        public void deleteLending(lendings lending,users user)
        {
            if (ConfirmCallback($"are you sure you want to return this book: {lending.Book.Title} ?"))
            {
                int lendingCount = Model.Lendings
                .Where(l => l.Id == lending.Id && l.User.Id == user.Id)
                .Select(l => l.Count)
                .FirstOrDefault();

            if (lendingCount > 0)
            {
                // Update the book quantity
                var book = Model.Books.FirstOrDefault(b => b == lending.Book);

                if (book != null)
                {
                    book.Count += lendingCount;
                }

                var lendingToUser = Model.LendingToUsers
                    .FirstOrDefault(ltu => ltu.BookLendt.Id == lending.Id);
           
                    if (lendingToUser != null)
                    {
                        Model.LendingToUsers.Remove(lendingToUser);
                    }


                    Model.Lendings.Remove(lending);
                    Model.SaveChanges();
                    LoadUserLendings();
                }
            }
        }
        private PlotModel GenerateLendingOverviewPlot()
        {
            var lendingOverview = from lending in Model.Lendings
                                  let book = lending.Book
                                  let user = lending.User
                                  select new
                                  {
                                      BookTitle = book.Title,
                                      BorrowerName = user.UsernameId,
                                      NumberOfCopiesBorrowed = lending.Count
                                  };

            var plotModel = new PlotModel { Title = "Lending Overview" };

            var barSeries = new BarSeries
            {
                Title = "Number of Copies Borrowed",
                ItemsSource = lendingOverview.Select(l => new BarItem { Value = l.NumberOfCopiesBorrowed })
            };

            plotModel.Series.Add(barSeries);

      
            plotModel.Axes.Add(new CategoryAxis { Position = AxisPosition.Left, ItemsSource = lendingOverview.Select(l => l.BookTitle) });

            return plotModel;
        }

        private PlotModel GenerateExpiredLoansOverviewPlot()
        {
            var overviewOfExpiredLoans = from lendings in Model.Lendings
                                         where lendings.Date < DateTime.Now.AddDays(-30)
                                         select new
                                         {
                                             BookTitle = lendings.Book.Title,
                                             BorrowerName = lendings.User.UsernameId,
                                             LoanDate = lendings.Date
                                         };

            var plotModel = new PlotModel { Title = "Expired Loans Overview" };

            var barSeries = new BarSeries
            {
                Title = "Number of Expired Loans",
                ItemsSource = overviewOfExpiredLoans.Select(e => new BarItem { Value = 1 }),
                LabelPlacement = LabelPlacement.Inside, 
                LabelFormatString = "{0:MM/dd/yyyy}"
            };

            plotModel.Series.Add(barSeries);

            plotModel.Axes.Add(new CategoryAxis { Position = AxisPosition.Left, ItemsSource = overviewOfExpiredLoans.Select(e => e.BookTitle) });

            return plotModel;
        }
        private PlotModel GenerateUsersOverviewPlot()
        {
            var userOverview = from user in Model.Users
                               let userLendings = from lending in Model.Lendings
                                                  where lending.User.Id == user.Id
                                                  select lending
                               select new
                               {
                                   UserName = user.UsernameId,
                                   ActiveLoans = userLendings.Count()
                               };

            var patronsWithMoreThanFourLoans = userOverview.Where(u => u.ActiveLoans >= 1);


            var plotModel = new PlotModel { Title = "Users Overview" };

        
            var barSeriesActiveLoans = new BarSeries
            {
                Title = "Active Loans",
                ItemsSource = patronsWithMoreThanFourLoans.Select(u => new BarItem { Value = u.ActiveLoans })
            };

        

            plotModel.Series.Add(barSeriesActiveLoans);
        

     
            plotModel.Axes.Add(new CategoryAxis { Position = AxisPosition.Left, ItemsSource = patronsWithMoreThanFourLoans.Select(u => u.UserName) });

            return plotModel;
        }
        private PlotModel GenerateBooksOverviewPlot()
        {
            var bookOverview = from book in Model.Books
                               let bookLendings = from lending in Model.Lendings
                                                  where lending.Book.Id == book.Id
                                                  select lending
                               select new
                               {
                                   BookTitle = book.Title,
                                   NumberOfCopiesLeft = book.Count,
                                   NumberOfLoanedCopies = bookLendings.Count()
                               };

            var plotModel = new PlotModel { Title = "Book Overview" };

            var barSeries = new BarSeries
            {
                Title = "Number of Copies",
                ItemsSource = bookOverview.Select(b => new BarItem { Value = b.NumberOfCopiesLeft })
            };

            var lineSeries = new LineSeries
            {
                Title = "Number of Loaned Copies",
                ItemsSource = bookOverview.Select(b => new BarItem { Value = b.NumberOfLoanedCopies })
            };

            plotModel.Series.Add(barSeries);
            plotModel.Series.Add(lineSeries);

            plotModel.Axes.Add(new CategoryAxis { Position = AxisPosition.Left, ItemsSource = bookOverview.Select(b => b.BookTitle) });

            return plotModel;
        }
        public void updateOverview(string selectedItem)
        {
            switch (selectedItem)
            {
                case "Books":
                    GraphModel = GenerateBooksOverviewPlot();
                    break;
                case "Users":
                    GraphModel = GenerateUsersOverviewPlot();
                    break;
                case "Lendings":
                    GraphModel = GenerateLendingOverviewPlot();
                    break;
                case "ExpiredLoans":
                    GraphModel = GenerateExpiredLoansOverviewPlot();
                    break;
                default:
                    SelectedData = new ObservableCollection<object>();
                    break;
            }
        }
        public void addLending(lendings lending, users user)
        {
            if (CanUserLendBooks(user.Id))
            {
 
                var book = Model.Books.FirstOrDefault(b => b == lending.Book);
                if (book != null && book.Count >= lending.Count)
                {
         
                    var newLending = new lendings
                    {
                        Date = DateTime.Now,
                        User = user,
                        Book = lending.Book,
                        Count = lending.Count
                    };


                 

 
                    var lastInsertedLending = newLending;

        
                    var newLendingToUser = new lendingToUser
                    {
                        BookLendt = lastInsertedLending,
                        UserLendtTo = user
                    };

                 
                  

                    try
                    {
                        Model.Lendings.Add(newLending);
                        Model.LendingToUsers.Add(newLendingToUser);
                        book.Count -= lending.Count;
                        OnPropertyChanged(nameof(bookss.Count));
                        Model.SaveChanges();
                        LoadUserLendings();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                
                }
                else
                {
                    throw new Exception("Insufficient book count. Unable to lend the requested quantity.");
                }
            }
            else
            {
                throw new Exception("User is not allowed to lend books at this time.");
            }
        }
        public void AddUser(users user)
        {
            var existingUser = Model.Users.FirstOrDefault(u => u.UsernameId == user.UsernameId);

            if (existingUser != null)
            {
                throw new Exception("User with the same username already exists.");
            }

            string hashedPassword = hash.hashPassword(user.Password);
            roles NewRole = new roles("user");
            users newUser = new users
            {
                UsernameId = user.UsernameId,
                Password = hashedPassword,
                Role = NewRole

            };
            newUser.Role = NewRole;
            Model.Users.Add(newUser);
            Model.Roles.Add(NewRole);
            Model.SaveChanges();
        }
        public void UpdateUser(users user, int id, string password)
        {
            var existingUser = Model.Users.FirstOrDefault(u => u.Id == user.Id);

            if (existingUser != null) { 
        
                existingUser.UsernameId = id;
                existingUser.Password = hash.hashPassword(password);

                Model.SaveChanges();
            }
            else
            {
                    throw new Exception("User not found.");
                }



        }
        public void DeleteUser(users user)
        {
            var existingUser = Model.Users.FirstOrDefault(u => u.Id == user.Id);

            if (existingUser != null)
            {
                if (ConfirmCallback($"are you sure you want to delete this User: ${user.UsernameId} ?"))
                {
                    var relatedLendings = Model.Lendings.Where(l => l.User.Id == user.Id).ToList();
                    if (relatedLendings.Any())
                    {
                        foreach (var lending in relatedLendings)
                        {
                            var book = lending.Book;
                            if (book != null)
                            {
                                book.Count += lending.Count;
                            }
                        }
                    }

                    var relatedLendingToUser = Model.LendingToUsers.Where(ltu => ltu.UserLendtTo.Id == user.Id).ToList();

                    if (relatedLendingToUser.Any())
                    {

                        Model.LendingToUsers.RemoveRange(relatedLendingToUser);
                    }
                    try
                    {
                        Model.Users.Remove(existingUser);
                        Model.SaveChanges();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                  
           
            }
        }
    }
}
