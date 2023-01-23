using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MauiAppTest2;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        TestCollectionView.ItemsLayout = new GridItemsLayout(3, ItemsLayoutOrientation.Vertical);

        var vm = this.BindingContext as TestViewModel;
        vm.CreateTestListItems();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        // Clear all the items from the CollectionView.
        var vm = this.BindingContext as TestViewModel;
        vm.TestListCollection.Clear();

        // Change the number of the columns that the CollectionView will show.
        TestCollectionView.ItemsLayout = new GridItemsLayout(4, ItemsLayoutOrientation.Vertical);

        // Repopulate the list.
        vm.CreateTestListItems();
    }
}

public class TestViewModel : INotifyPropertyChanged
{
    private ObservableCollection<TestCard> testList;
    public ObservableCollection<TestCard> TestListCollection
    {
        get { return testList; }
        set { this.testList = value; }
    }

    public TestViewModel()
    {
        testList = new ObservableCollection<TestCard>();
    }

    public void CreateTestListItems()
    {
        testList.Add(new TestCard("Jay"));
        testList.Add(new TestCard("Blackbird"));
        testList.Add(new TestCard("Thrush"));
        testList.Add(new TestCard("Sparrowhawk"));
        testList.Add(new TestCard("Pigeon"));
        testList.Add(new TestCard("Robin"));
        testList.Add(new TestCard("Sparrow"));
        testList.Add(new TestCard("Crow"));
        testList.Add(new TestCard("Dunnock"));
    }

    protected bool SetProperty<T>(ref T backingStore, T value,
        [CallerMemberName] string propertyName = "",
        Action onChanged = null)
    {
        if (EqualityComparer<T>.Default.Equals(backingStore, value))
            return false;

        backingStore = value;
        onChanged?.Invoke();
        OnPropertyChanged(propertyName);
        return true;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        var changed = PropertyChanged;
        if (changed == null)
            return;

        changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public class TestCard : INotifyPropertyChanged
{
    public TestCard(string name)
    {
        this.Name = name;
    }

    private string name;
    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            SetProperty(ref name, value);
        }
    }

    protected bool SetProperty<T>(ref T backingStore, T value,
        [CallerMemberName] string propertyName = "",
        Action onChanged = null)
    {
        if (EqualityComparer<T>.Default.Equals(backingStore, value))
            return false;

        backingStore = value;
        onChanged?.Invoke();
        OnPropertyChanged(propertyName);
        return true;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        var changed = PropertyChanged;
        if (changed == null)
            return;

        changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
