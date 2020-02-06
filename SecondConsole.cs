using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using SecondConsoleAPI.Exeption;

namespace SecondConsoleAPI
{
    /// <summary>
    /// Enebles you to open a second console window
    /// </summary>
    /// <remarks>can be handy for debugging</remarks>
    public class SecondConsole
    {
        /// <summary>
        /// Gets or Sets the width of the Console Window
        /// </summary>
        public int Width { get { return this.Window.Width; } set { this.Window.Invoke((MethodInvoker)(() => { this.Window.Width = value; })); } }
        /// <summary>
        /// Gets or Sets the heigt of the Console Window
        /// </summary>
        public int Heigt { get { return this.Window.Height; } set { this.Window.Invoke((MethodInvoker)(() => { this.Window.Height = value; })); } }
        /// <summary>
        /// Gets or Sets the fontsize of the Console's Text
        /// </summary>
        public int FontSize { get { return Convert.ToInt32(this.Window.Font.Size); } set { this.Window.Invoke((MethodInvoker)(() => { this.Window.Font = new Font(this.Window.Font.Name, value, this.Window.Font.Style, this.Window.Font.Unit); })); } }
        /// <summary>
        /// Returns if the Window is visible
        /// </summary>
        public bool IsOpen { get { try { return this.Window.Visible; } catch { return false; } } }
        /// <summary>
        /// Gets or Sets if the icon in the titlebar is shown
        /// </summary>
        public bool ShowIcon { get { return this.Window.ShowIcon; } set { this.Window.Invoke((MethodInvoker)(() => { this.Window.ShowIcon = value; })); } }

        private String Title;
        private Thread Window_Thread;
        private Form Window;
        private RichTextBox Window_Text;
        private Label dummy;
        private bool IsInitialized;
        private bool pre_showicon;
        private int pre_width;
        private int pre_heigt;
        private int pre_fontsize;
        private bool canwrite;

        /// <summary>
        /// Initializes the SecondConsole without any parameters
        /// </summary>
        public SecondConsole() => SetUp("SecondConsole", 800, 500, 12, false);
        /// <summary>
        /// Initializes the SecondConsole
        /// </summary>
        /// <param name="title">The Window's title</param>
        public SecondConsole(String title) => SetUp(title, 800, 500, 12, false);
        /// <summary>
        /// Initializes the SecondConsole
        /// </summary>
        /// <param name="title">The Window's title</param>
        /// <param name="showicon">Set the titlebar's icon on or off</param>
        public SecondConsole(String title, bool showicon) => SetUp(title, 800, 500, 12, showicon);
        /// <summary>
        /// Initializes the SecondConsole
        /// </summary>
        /// <param name="title">The Window's title</param>
        /// <param name="width">The Window's width</param>
        /// <param name="heigt">The Window's heigt</param>
        public SecondConsole(String title, int width, int heigt) => SetUp(title, width, heigt, 12, false);
        /// <summary>
        /// Initializes the SecondConsole
        /// </summary>
        /// <param name="title">The Window's title</param>
        /// <param name="fontsize">The Window's font</param>
        public SecondConsole(String title, int fontsize) => SetUp(title, 800, 500, fontsize, false);
        /// <summary>
        /// Initializes the SecondConsole
        /// </summary>
        /// <param name="title">The Window's title</param>
        /// <param name="fontsize">The Window's font</param>
        /// <param name="showicon">Set the titlebar's icon on or off</param>
        public SecondConsole(String title, int fontsize, bool showicon) => SetUp(title, 800, 500, fontsize, showicon);
        /// <summary>
        /// Initializes the SecondConsole
        /// </summary>
        /// <param name="title">The Window's title</param>
        /// <param name="width">The Window's width</param>
        /// <param name="heigt">The Window's heigt</param>
        /// <param name="fontsize">>The Window's font</param>
        public SecondConsole(String title, int width, int heigt, int fontsize) => SetUp(title, width, heigt, fontsize, false);
        /// <summary>
        /// Initializes the SecondConsole
        /// </summary>
        /// <param name="title">The Window's title</param>
        /// <param name="width">The Window's width</param>
        /// <param name="heigt">The Window's heigt</param>
        /// <param name="fontsize">The Window's font</param>
        /// <param name="showicon">Set the titlebar's icon on or off</param>
        public SecondConsole(String title, int width, int heigt, int fontsize, bool showicon) => SetUp(title, width, heigt, fontsize, showicon);
        /// <summary>
        /// Opens the Console Window in a new Thread
        /// </summary>
        /// <remarks>Can only be called once per instance</remarks>
        public void Open()
        {
            if (!this.IsInitialized)
            {
                this.Window_Thread = new Thread(SetUpWindow);
                this.Window_Thread.Name = this.Title;
                this.Window_Thread.Start();
                while (!this.IsInitialized)
                {

                }
                this.canwrite = true;
            }
            else
                throw new AlreadyOpenedException("Open() can only be called once per instance.");
        }
        /// <summary>
        /// Closes the Console Window and terminates the Thread
        /// </summary>
        public void Close()
        {
            if (this.IsInitialized)
            {
                this.Window.Invoke((MethodInvoker)(() => { this.Window.Close(); }));
                this.Window_Thread.Abort();
            }
            else
                throw new NotInitializedExeption("Before using the SecondConsole you have to open it.");
        }
        /// <summary>
        /// Writes into the Second Console
        /// </summary>
        /// <param name="value">writes a boolean value</param>
        public void Write(bool value) => Print(value.ToString(), SecondConsoleColors.White, false, false);
        /// <summary>
        /// Writes into the Second Console
        /// </summary>
        /// <param name="value">writes a String value</param>
        public void Write(String value) => Print(value, SecondConsoleColors.White, false, false);
        /// <summary>
        /// Writes into the Second Console
        /// </summary>
        /// <param name="value"></param>
        public void Write(object value) => Print(value.ToString(), SecondConsoleColors.White, false, false);
        /// <summary>
        /// Writes into the console and creates a new line
        /// </summary>
        public void WriteLine() => Print("", SecondConsoleColors.White, true, false);
        /// <summary>
        /// Writes into the console and creates a new line
        /// </summary>
        public void WriteLine(bool value) => Print(value.ToString(), SecondConsoleColors.White, true, false);
        /// <summary>
        /// Writes into the console and creates a new line
        /// </summary>
        public void WriteLine(String value) => Print(value, SecondConsoleColors.White, true, false);
        /// <summary>
        /// Writes into the console and creates a new line
        /// </summary>
        public void WriteLine(object value) => Print(value.ToString(), SecondConsoleColors.White, true, false);
        /// <summary>
        /// Writes into the Second Console
        /// </summary>
        /// <param name="color">The text color</param>
        public void WriteColor(SecondConsoleColors color, bool value) => Print(value.ToString(), color, false, false);
        /// <summary>
        /// Writes into the Second Console
        /// </summary>
        /// <param name="color">The text color</param>
        public void WriteColor(SecondConsoleColors color, String value) => Print(value, color, false, false);
        /// <summary>
        /// Writes into the Second Console
        /// </summary>
        /// <param name="color">The text color</param>
        public void WriteColor(SecondConsoleColors color, object value) => Print(value.ToString(), color, false, false);
        /// <summary>
        /// Writes into the console and creates a new line
        /// </summary>
        /// <param name="color">The text color</param>
        public void WriteLineColor(SecondConsoleColors color, bool value) => Print(value.ToString(), color, true, false);
        /// <summary>
        /// Writes into the console and creates a new line
        /// </summary>
        /// <param name="color">The text color</param>
        public void WriteLineColor(SecondConsoleColors color, String value) => Print(value, color, true, false);
        /// <summary>
        /// Writes into the console and creates a new line
        /// </summary>
        /// <param name="color">The text color</param>
        public void WriteLineColor(SecondConsoleColors color, object value) => Print(value.ToString(), color, true, false);
        /// <summary>
        /// Writes a colorful String into the Console
        /// </summary>
        public void WriteFormatted(String value) => Print(value, SecondConsoleColors.White, false, true);
        /// <summary>
        /// Writes a colorful String into the Console
        /// </summary>
        public void WriteLineFormatted(String value) => Print(value, SecondConsoleColors.White, true, true);
        /// <summary>
        /// Clears the output of the SecondConsole
        /// </summary>
        public void Clear()
        {
            if (this.IsInitialized)
            {
                this.Window_Text.Invoke((MethodInvoker)(() => {
                    Window_Text.Text = "";
                }));
            }
            else
                throw new NotInitializedExeption("Before using the SecondConsole you have to open it.");
        }

        private void SetUp(String title, int with, int heigt, int fontsize, bool showicon)
        {
            this.Title = title;
            this.pre_showicon = showicon;
            this.pre_width = with;
            this.pre_heigt = heigt;
            this.pre_fontsize = fontsize;
            this.IsInitialized = false;
        }
        private void SetUpWindow()
        {
            try
            {
                this.Window = new Form();
                this.Window.Text = this.Title;
                this.Window.BackColor = Color.Black;
                this.Window.ShowIcon = this.pre_showicon;
                this.Window.Font = new Font("Consolas", pre_fontsize, FontStyle.Regular, GraphicsUnit.Point);
                this.Window.Width = pre_width;
                this.Window.Height = pre_heigt;
                this.Window.StartPosition = FormStartPosition.Manual;
                this.Window.Location = Screen.AllScreens[1].WorkingArea.Location;
                this.dummy = new Label();
                this.dummy.Visible = true;
                this.dummy.Height = 0;
                this.dummy.Width = 0;
                this.dummy.SendToBack();
                this.Window.Controls.Add(dummy);
                this.Window_Text = new RichTextBox();
                this.Window_Text.ReadOnly = true;
                this.Window_Text.BorderStyle = BorderStyle.None;
                this.Window_Text.Width = this.Window.Width;
                this.Window_Text.Height = this.Window.Height;
                this.Window_Text.BackColor = Color.Black;
                this.Window_Text.ForeColor = Color.White;
                this.Window_Text.HideSelection = true;
                this.Window_Text.SelectionChanged += delegate (object sender, EventArgs e) { this.Window_Text.SelectionLength = 0; };
                this.Window_Text.GotFocus += delegate (object sender, EventArgs e) { this.dummy.Focus(); };
                this.Window_Text.TextChanged += delegate (object sender, EventArgs e) { this.Window_Text.SelectionStart = this.Window_Text.Text.Length; this.Window_Text.ScrollToCaret(); };
                this.Window.SizeChanged += delegate (object sender, EventArgs e) { this.Window_Text.Width = this.Window.Width; this.Window_Text.Height = this.Window.Height - 20; };
                this.Window.Controls.Add(Window_Text);
                this.Window.Show();
                this.IsInitialized = true;
                Application.Run(this.Window);
            }
            catch
            {

            }
        }
        private void Print(String Text, SecondConsoleColors color, bool IsLine, bool isformatted)
        {
            if (this.IsInitialized)
            {
                try
                {
                    while (!this.canwrite)
                    {

                    }
                    if (this.IsInitialized)
                    {
                        this.Window_Text.BeginInvoke((MethodInvoker)(() => {
                            if (Window_Text.Lines.Length > 200)
                                Window_Text.Text = "";
                        }));
                        this.canwrite = false;
                        if (!isformatted)
                        {
                            this.Window_Text.BeginInvoke((MethodInvoker)(() => {
                                Window_Text.SelectionStart = Window_Text.TextLength;
                                Window_Text.SelectionLength = 0;
                                Window_Text.SelectionColor = ColorTools.GetColor(color, Color.White);
                                if (IsLine)
                                    Window_Text.AppendText(Text + "\n");
                                else
                                    Window_Text.AppendText(Text);
                                Window_Text.SelectionColor = Window_Text.ForeColor;
                            }));
                        }
                        else
                        {
                            String[] parts = Text.Split('%');
                            foreach (String scope in parts)
                            {
                                if (scope != "" & scope != null)
                                {
                                    this.Window_Text.BeginInvoke((MethodInvoker)(() => {
                                        Window_Text.SelectionStart = Window_Text.TextLength;
                                        Window_Text.SelectionLength = 0;
                                        Window_Text.SelectionColor = ColorTools.GetColorByFormattedChar(ColorTools.NormalizeFormattedChar(scope[0]), Color.White);
                                        Window_Text.AppendText(scope.Substring(1));
                                        Window_Text.SelectionColor = Window_Text.ForeColor;
                                    }));
                                }
                            }
                            if (IsLine)
                            {
                                this.Window_Text.BeginInvoke((MethodInvoker)(() => {
                                    Window_Text.AppendText("\n");
                                    Window_Text.SelectionColor = Window_Text.ForeColor;
                                }));
                            }
                        }
                        this.canwrite = true;
                    }
                    else
                        throw new NotInitializedExeption("Before using the SecondConsole you have to open it.");
                }
                catch (Exception e)
                {
                    if (e.GetType() == new NotInitializedExeption().GetType())
                        throw new NotInitializedExeption("Before using the SecondConsole you have to open it.");
                    this.canwrite = true;
                }
            }         
        }
    }
}