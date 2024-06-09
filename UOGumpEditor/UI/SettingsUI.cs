﻿namespace UOGumpEditor
{
    public partial class SettingsUI : Form
    {
        private ListBox GumpNameListbox;

        public SettingsUI()
        {
            InitializeComponent();

            GumpNameListbox = UOArtLoader.GumpListBox;
        }

        private void SettingsUI_Load(object sender, EventArgs e)
        {
            GumpNameListbox.SelectedIndexChanged += GumpNameListbox_SelectedIndexChanged1;

            GumpListPanel.Controls.Add(GumpNameListbox);

            FontTextbox.Text = UOSettings.Default.FontSize.ToString();

            MaxSearchTextbox.Text = UOSettings.Default.DisplayMax.ToString();

            PreviewTextbox.Text = UOSettings.Default.PreviewSticky.ToString();

            ExportCombobox.SelectedIndex = 0;

            LanguageCombobox.SelectedIndex = 0;
        }

        private void SetFontButton_Click(object sender, EventArgs e)
        {
            if (float.TryParse(FontTextbox.Text, out float size))
            {
                UOSettings.Default.FontSize = size;

                UOSettings.Default.Save();
            }
            else
            {
                FontTextbox.Text = UOSettings.Default.FontSize.ToString();
            }
        }

        private void SetNameButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(GumpNameTextbox.Text))
            {
                var nameInfo = GumpNameTextbox.Text.Split(':');

                if (nameInfo.Length == 2 && int.TryParse(nameInfo[0], out int val))
                {
                    UOArtLoader.UpdateGumpName(val, nameInfo[1]);

                    UOArtLoader.GumpListBox.Update();
                }
            }
        }

        private void GumpNameListbox_SelectedIndexChanged1(object? sender, EventArgs e)
        {
            if (UOArtLoader.GumpListBox.SelectedValue != null)
            {
                GumpNameTextbox.Text = UOArtLoader.GumpListBox.SelectedValue.ToString();
            }
        }

        private void MaxSearchButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(MaxSearchTextbox.Text, out int size))
            {
                UOSettings.Default.DisplayMax = size;

                UOSettings.Default.Save();
            }
            else
            {
                FontTextbox.Text = UOSettings.Default.DisplayMax.ToString();
            }
        }

        private void PreviewButton_Click(object sender, EventArgs e)
        {
            UOSettings.Default.PreviewSticky = !UOSettings.Default.PreviewSticky;

            UOSettings.Default.Save();

            PreviewTextbox.Text = UOSettings.Default.PreviewSticky.ToString();
        }

        private void ExportCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ExportCombobox.SelectedIndex > -1)
            {
                UOSettings.Default.ExportType = ExportCombobox.SelectedIndex;

                UOSettings.Default.Save();
            }
        }

        private void LanguageCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LanguageCombobox.SelectedIndex > -1)
            {
                UOSettings.Default.LanguageType = LanguageCombobox.SelectedIndex;

                UOSettings.Default.Save();
            }
        }

        private void BackgroundButton_Click(object sender, EventArgs e)
        {
            UOEditorCore.PromptUserForImage();

            if (File.Exists(UOArtLoader.BGImageFile))
            {
                BackgroundTextbox.Text = "User Image";
            }
        }

        private void ArtDisplayButton_Click(object sender, EventArgs e)
        {
            ArtDisplayColorPanel.BackColor = UOEditorCore.PromptUserForColor();

            UOSettings.Default.ArtDisplayColor = ArtDisplayColorPanel.BackColor;

            UOSettings.Default.Save();
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            UOSettings.Default.Reset();

            UOSettings.Default.Save();
        }
    }
}
