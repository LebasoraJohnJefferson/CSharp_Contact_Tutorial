using Contacts.Maui.Models;

namespace Contacts.Maui.Views;
using Contact = Contacts.Maui.Models.Contact;

//attributes
[QueryProperty(nameof(ContactId), "Id")]
public partial class EditContactPage : ContentPage
{
    private Contact contact;
	public EditContactPage()
	{
		InitializeComponent();
	}

    private void cancelEdit(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }

    public string ContactId
    {
        set 
        {
            if (int.TryParse(value, out int id))
            {
                contact = ContactRepository.GetContactById(id);
                if (contact == null) return;

                contactControl.Name = contact.Name;
                contactControl.Email = contact.Email;
                contactControl.Address = contact.Address;
                contactControl.Phone = contact.Phone;
            }
        }
    }

    private void errorMessage(object sender, string e)
    {
        DisplayAlert("Error", e,"Ok");
    }

    private void updateContact(object sender, EventArgs e) 
    {
        
        contact.Name = contactControl.Name;
        contact.Phone = contactControl.Phone;
        contact.Address= contactControl.Address;
        contact.Email= contactControl.Email;
        ContactRepository.UpdateContact(contact.ContactId,contact);
        Shell.Current.GoToAsync($"//{nameof(ContactsPage)}");
    }
}