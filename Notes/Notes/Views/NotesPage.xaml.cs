using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Notes.Models;
using Xamarin.Forms;

namespace Notes.Views
{
    public partial class NotesPage : ContentPage
    {
        public NotesPage()
        {
            InitializeComponent();
        }
        /*
         * When the page appears, the OnAppearing method is executed,
         * which populates the CollectionView with any notes that
         * have been retrieved from the local application data folder.
         * 
         */
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Retrieve all the notes from the database, and set them as the
            // data source for the CollectionView.
            collectionView.ItemsSource = await App.Database.GetNotesAsync();
        }

        /*
         * When the ToolbarItem is pressed the OnAddClicked event handler
         * is executed. This method navigates to the NoteEntryPage.
         */
        async void OnAddClicked(object sender, EventArgs e)
        {
            // Navigate to the NoteEntryPage, without passing any data.
            await Shell.Current.GoToAsync(nameof(NoteEntryPage));
        }

        /*
         * When an item in the CollectionView is selected the
         * OnSelectionChanged event handler is executed. This
         * method navigates to the NoteEntryPage, provided that an
         * item in the CollectionView is selected, passing the
         * Filename property of the selected Note as a query
         * parameter to the page.
         */
        async void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                // Navigate to the NoteEntryPage, passing the filename as a query parameter.
                Note note = (Note)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(NoteEntryPage)}?{nameof(NoteEntryPage.ItemId)}={note.ID.ToString()}");
            }
        }
    }
}