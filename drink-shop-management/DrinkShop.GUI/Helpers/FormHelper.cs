namespace DrinkShop.GUI.Helpers;

public static class FormHelper
{
    private static Form? _currentChildForm;

    public static void OpenChildForm(Form childForm, Panel targetPanel)
    {
        ArgumentNullException.ThrowIfNull(childForm);
        ArgumentNullException.ThrowIfNull(targetPanel);

        if (_currentChildForm is not null)
        {
            targetPanel.Controls.Remove(_currentChildForm);
            _currentChildForm.Close();
            _currentChildForm.Dispose();
        }

        _currentChildForm = childForm;
        childForm.TopLevel = false;
        childForm.FormBorderStyle = FormBorderStyle.None;
        childForm.Dock = DockStyle.Fill;
        targetPanel.Controls.Clear();
        targetPanel.Controls.Add(childForm);
        targetPanel.Tag = childForm;
        childForm.Show();
        childForm.BringToFront();
    }

    public static void CloseCurrentChildForm(Panel targetPanel)
    {
        if (_currentChildForm is null)
        {
            return;
        }

        targetPanel.Controls.Remove(_currentChildForm);
        _currentChildForm.Close();
        _currentChildForm.Dispose();
        _currentChildForm = null;
        targetPanel.Tag = null;
    }
}
