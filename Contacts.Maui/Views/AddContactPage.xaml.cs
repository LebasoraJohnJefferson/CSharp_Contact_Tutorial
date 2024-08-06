using Contacts.Maui.Models;

namespace Contacts.Maui.Views;

public partial class AddContactPage : ContentPage
{
	public AddContactPage()
	{
		InitializeComponent();
	}

	private void Cancel(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("..");
	}

    private void OnSave(object sender, EventArgs e)
    {
		ContactRepository.AddContact(new Models.Contact {
            Name = contactControl.Name,
            Phone = contactControl.Phone,
            Address = contactControl.Address,
            Email = contactControl.Email
        });
        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
        DisplayAlert("Success","Contact Added","Ok");
    }

	private void OnCancel(object sender, EventArgs e)
	{
        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }

	private void errorMessage(object sender, string e)
	{
        DisplayAlert("Error", e, "Ok");
    }



}