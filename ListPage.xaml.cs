using MariesNadiraLab4.Models;

namespace MariesNadiraLab4;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
        InitializeComponent();
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var shopl = (ShopList)BindingContext;
        listView.ItemsSource = await App.Database.GetListProductsAsync(shopl.ID);
    }
    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (ShopList)BindingContext;
        slist.Date = DateTime.UtcNow;
        await App.Database.SaveShopListAsync(slist);
        await Navigation.PopAsync();
    }
    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (ShopList)BindingContext;
        await App.Database.DeleteShopListAsync(slist);
        await Navigation.PopAsync();



    }
    async void OnDeleteItemButtonClicked(object sender, EventArgs e)

    {

      /*  var sl = (ShopList)BindingContext;

        var p = listView.SelectedItem as Product;

        var lp = await App.Database.GetListProductAsync(sl.ID, p.ID);

        await App.Database.DeleteListProductAsync(lp);
      */


    }
    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProductPage((ShopList)this.BindingContext)
        {
            BindingContext = new Product()
        });
    }
    
    
}