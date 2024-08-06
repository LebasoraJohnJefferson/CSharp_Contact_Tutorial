using Contacts.Maui.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Contact = Contacts.Maui.Models.Contact;

namespace Contacts.Maui.Views;

public partial class ContactsPage : ContentPage
{
	public ContactsPage()
	{
		InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        SearchBar.Text = string.Empty;
        LoadContacts();
    }

    private async void itemSeleceted(object sender,SelectedItemChangedEventArgs e) 
	{
		if (listContacts.SelectedItem == null) return;
		//query paramaters using id
		await Shell.Current.GoToAsync($"{nameof(EditContactPage)}?Id={((Contact)listContacts.SelectedItem).ContactId}");
	}

	private void itemTapped(object sender, ItemTappedEventArgs e) 
	{
		listContacts.SelectedItem = null;
	}

    private void addBtn_Clicked(object sender, EventArgs e)
    {
		Shell.Current.GoToAsync(nameof(AddContactPage));
    }

    private void DeleteClicked(object sender, EventArgs e)
    {
        var manuItem = sender as MenuItem;
        if (manuItem == null) return;
        var contactId = manuItem.CommandParameter as int?;
        if (contactId == null) return;
        ContactRepository.DeleteContact(contactId.Value);
        LoadContacts();
        DisplayAlert("Success", "Contact deleted!", "Ok");
    }

    private void LoadContacts() 
    {
        var contacts = new ObservableCollection<Contact>(ContactRepository.GetContacts());
        listContacts.ItemsSource = contacts;
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        var contacts = new ObservableCollection<Contact>(ContactRepository.SearchContacts(((SearchBar)sender).Text));
        listContacts.ItemsSource = contacts;
    }

    
}