namespace Contacts.Maui.Views.Controls;

public partial class ContactControl : ContentView
{
    public event EventHandler<string> OnError;
    public event EventHandler<EventArgs> OnSave;
    public event EventHandler<EventArgs> OnCancel;
    public ContactControl()
	{
		InitializeComponent();
	}

    public string Name
    {
        get => entryName.Text;
        set => entryName.Text = value;
    }

    public string Email
    {
        get => entryEmail.Text;
        set => entryEmail.Text = value;
    }

    public string Address
    {
        get => entryAddress.Text;
        set => entryAddress.Text = value;
    }

    public string Phone
    {
        get => entryPhone.Text;
        set => entryPhone.Text = value;
    }

    private void saveContact(object sender, EventArgs e)
    {
        if (nameValidator.IsNotValid)
        {
            OnError?.Invoke(sender, "Name is required");
            return;
        }

        if (emailValidator.IsNotValid && emailValidator.Errors != null)
        {
            string message = "";
            foreach (var error in emailValidator.Errors)
            {
                if (error == null) return;
                message += message == null ? error.ToString() : "\n"+ error.ToString();
            }
            OnError?.Invoke(sender, message);
            return;
        }
        OnSave?.Invoke(sender, e);
    }

    private void cancelChanges(object sender, EventArgs e)
    {
        OnCancel?.Invoke(sender, e);
    }



}