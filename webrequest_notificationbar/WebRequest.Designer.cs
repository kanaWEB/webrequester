namespace WebRequester
{
    partial class NotificationBar
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                _hotKeyManager.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotificationBar));
            this.BarIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.URL = new System.Windows.Forms.TextBox();
            this.ActionON_Text = new System.Windows.Forms.TextBox();
            this.Token = new System.Windows.Forms.TextBox();
            this.URL_Label = new System.Windows.Forms.Label();
            this.Token_Label = new System.Windows.Forms.Label();
            this.Label_ActionON = new System.Windows.Forms.Label();
            this.Label_ActionOFF = new System.Windows.Forms.Label();
            this.ActionOFF_Text = new System.Windows.Forms.TextBox();
            this.CheckServer_Button = new System.Windows.Forms.Button();
            this.Save_Button = new System.Windows.Forms.Button();
            this.Group_Action = new System.Windows.Forms.GroupBox();
            this.ActionOFF_Button = new System.Windows.Forms.Button();
            this.ActionON_Button = new System.Windows.Forms.Button();
            this.Label_HotKeys = new System.Windows.Forms.Label();
            this.ActionOFFKey_Text = new System.Windows.Forms.TextBox();
            this.ActionONKey_Text = new System.Windows.Forms.TextBox();
            this.Group_Server = new System.Windows.Forms.GroupBox();
            this.startOnBoot = new System.Windows.Forms.CheckBox();
            this.Group_Action.SuspendLayout();
            this.Group_Server.SuspendLayout();
            this.SuspendLayout();
            // 
            // BarIcon
            // 
            this.BarIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("BarIcon.Icon")));
            this.BarIcon.Text = "Web Requester";
            this.BarIcon.Visible = true;
            // 
            // URL
            // 
            this.URL.Location = new System.Drawing.Point(21, 32);
            this.URL.Name = "URL";
            this.URL.Size = new System.Drawing.Size(549, 20);
            this.URL.TabIndex = 0;
            this.URL.Text = "maison/actions.php";
            // 
            // ActionON_Text
            // 
            this.ActionON_Text.Location = new System.Drawing.Point(24, 32);
            this.ActionON_Text.Name = "ActionON_Text";
            this.ActionON_Text.Size = new System.Drawing.Size(262, 20);
            this.ActionON_Text.TabIndex = 1;
            // 
            // Token
            // 
            this.Token.Location = new System.Drawing.Point(21, 71);
            this.Token.Name = "Token";
            this.Token.Size = new System.Drawing.Size(549, 20);
            this.Token.TabIndex = 2;
            this.Token.Text = "1234";
            // 
            // URL_Label
            // 
            this.URL_Label.AutoSize = true;
            this.URL_Label.Location = new System.Drawing.Point(18, 16);
            this.URL_Label.Name = "URL_Label";
            this.URL_Label.Size = new System.Drawing.Size(29, 13);
            this.URL_Label.TabIndex = 3;
            this.URL_Label.Text = "URL";
            // 
            // Token_Label
            // 
            this.Token_Label.AutoSize = true;
            this.Token_Label.Location = new System.Drawing.Point(18, 55);
            this.Token_Label.Name = "Token_Label";
            this.Token_Label.Size = new System.Drawing.Size(38, 13);
            this.Token_Label.TabIndex = 4;
            this.Token_Label.Text = "Token";
            // 
            // Label_ActionON
            // 
            this.Label_ActionON.AutoSize = true;
            this.Label_ActionON.Location = new System.Drawing.Point(6, 16);
            this.Label_ActionON.Name = "Label_ActionON";
            this.Label_ActionON.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label_ActionON.Size = new System.Drawing.Size(23, 13);
            this.Label_ActionON.TabIndex = 5;
            this.Label_ActionON.Text = "ON";
            // 
            // Label_ActionOFF
            // 
            this.Label_ActionOFF.AutoSize = true;
            this.Label_ActionOFF.Location = new System.Drawing.Point(6, 65);
            this.Label_ActionOFF.Name = "Label_ActionOFF";
            this.Label_ActionOFF.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label_ActionOFF.Size = new System.Drawing.Size(27, 13);
            this.Label_ActionOFF.TabIndex = 6;
            this.Label_ActionOFF.Text = "OFF";
            // 
            // ActionOFF_Text
            // 
            this.ActionOFF_Text.Location = new System.Drawing.Point(24, 81);
            this.ActionOFF_Text.Name = "ActionOFF_Text";
            this.ActionOFF_Text.Size = new System.Drawing.Size(262, 20);
            this.ActionOFF_Text.TabIndex = 7;
            // 
            // CheckServer_Button
            // 
            this.CheckServer_Button.Location = new System.Drawing.Point(21, 108);
            this.CheckServer_Button.Name = "CheckServer_Button";
            this.CheckServer_Button.Size = new System.Drawing.Size(549, 23);
            this.CheckServer_Button.TabIndex = 8;
            this.CheckServer_Button.Text = "Check Server";
            this.CheckServer_Button.UseVisualStyleBackColor = true;
            this.CheckServer_Button.Click += new System.EventHandler(this.CheckServer_Button_Click);
            // 
            // Save_Button
            // 
            this.Save_Button.Location = new System.Drawing.Point(6, 287);
            this.Save_Button.Name = "Save_Button";
            this.Save_Button.Size = new System.Drawing.Size(466, 65);
            this.Save_Button.TabIndex = 9;
            this.Save_Button.Text = "Save configuration";
            this.Save_Button.UseVisualStyleBackColor = true;
            this.Save_Button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SaveConfiguration_Click);
            // 
            // Group_Action
            // 
            this.Group_Action.Controls.Add(this.ActionOFF_Button);
            this.Group_Action.Controls.Add(this.ActionON_Button);
            this.Group_Action.Controls.Add(this.Label_HotKeys);
            this.Group_Action.Controls.Add(this.ActionOFFKey_Text);
            this.Group_Action.Controls.Add(this.ActionONKey_Text);
            this.Group_Action.Controls.Add(this.ActionON_Text);
            this.Group_Action.Controls.Add(this.Label_ActionOFF);
            this.Group_Action.Controls.Add(this.Label_ActionON);
            this.Group_Action.Controls.Add(this.ActionOFF_Text);
            this.Group_Action.Location = new System.Drawing.Point(6, 169);
            this.Group_Action.Name = "Group_Action";
            this.Group_Action.Size = new System.Drawing.Size(576, 112);
            this.Group_Action.TabIndex = 10;
            this.Group_Action.TabStop = false;
            this.Group_Action.Text = "Action";
            // 
            // ActionOFF_Button
            // 
            this.ActionOFF_Button.Location = new System.Drawing.Point(479, 79);
            this.ActionOFF_Button.Name = "ActionOFF_Button";
            this.ActionOFF_Button.Size = new System.Drawing.Size(91, 23);
            this.ActionOFF_Button.TabIndex = 14;
            this.ActionOFF_Button.Text = "Test";
            this.ActionOFF_Button.UseVisualStyleBackColor = true;
            this.ActionOFF_Button.Click += new System.EventHandler(this.ActionOFF_Click);
            // 
            // ActionON_Button
            // 
            this.ActionON_Button.Location = new System.Drawing.Point(479, 30);
            this.ActionON_Button.Name = "ActionON_Button";
            this.ActionON_Button.Size = new System.Drawing.Size(91, 23);
            this.ActionON_Button.TabIndex = 9;
            this.ActionON_Button.Text = "Test";
            this.ActionON_Button.UseVisualStyleBackColor = true;
            this.ActionON_Button.Click += new System.EventHandler(this.ActionON_Click);
            // 
            // Label_HotKeys
            // 
            this.Label_HotKeys.AutoSize = true;
            this.Label_HotKeys.Location = new System.Drawing.Point(289, 16);
            this.Label_HotKeys.Name = "Label_HotKeys";
            this.Label_HotKeys.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label_HotKeys.Size = new System.Drawing.Size(47, 13);
            this.Label_HotKeys.TabIndex = 13;
            this.Label_HotKeys.Text = "HotKeys";
            // 
            // ActionOFFKey_Text
            // 
            this.ActionOFFKey_Text.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ActionOFFKey_Text.ForeColor = System.Drawing.SystemColors.Window;
            this.ActionOFFKey_Text.Location = new System.Drawing.Point(292, 81);
            this.ActionOFFKey_Text.Name = "ActionOFFKey_Text";
            this.ActionOFFKey_Text.ReadOnly = true;
            this.ActionOFFKey_Text.Size = new System.Drawing.Size(181, 20);
            this.ActionOFFKey_Text.TabIndex = 12;
            this.ActionOFFKey_Text.Text = "None";
            this.ActionOFFKey_Text.Enter += new System.EventHandler(this.SetKey_Focus);
            this.ActionOFFKey_Text.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetKey);
            this.ActionOFFKey_Text.Leave += new System.EventHandler(this.SetKey_Leave);
            // 
            // ActionONKey_Text
            // 
            this.ActionONKey_Text.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ActionONKey_Text.ForeColor = System.Drawing.SystemColors.Window;
            this.ActionONKey_Text.Location = new System.Drawing.Point(292, 30);
            this.ActionONKey_Text.Name = "ActionONKey_Text";
            this.ActionONKey_Text.ReadOnly = true;
            this.ActionONKey_Text.Size = new System.Drawing.Size(181, 20);
            this.ActionONKey_Text.TabIndex = 11;
            this.ActionONKey_Text.Text = "None";
            this.ActionONKey_Text.Enter += new System.EventHandler(this.SetKey_Focus);
            this.ActionONKey_Text.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SetKey);
            this.ActionONKey_Text.Leave += new System.EventHandler(this.SetKey_Leave);
            // 
            // Group_Server
            // 
            this.Group_Server.Controls.Add(this.URL_Label);
            this.Group_Server.Controls.Add(this.CheckServer_Button);
            this.Group_Server.Controls.Add(this.URL);
            this.Group_Server.Controls.Add(this.Token);
            this.Group_Server.Controls.Add(this.Token_Label);
            this.Group_Server.Location = new System.Drawing.Point(6, 12);
            this.Group_Server.Name = "Group_Server";
            this.Group_Server.Size = new System.Drawing.Size(576, 151);
            this.Group_Server.TabIndex = 11;
            this.Group_Server.TabStop = false;
            this.Group_Server.Text = "Server Configuration";
            // 
            // startOnBoot
            // 
            this.startOnBoot.AutoSize = true;
            this.startOnBoot.Location = new System.Drawing.Point(478, 287);
            this.startOnBoot.Name = "startOnBoot";
            this.startOnBoot.Size = new System.Drawing.Size(96, 17);
            this.startOnBoot.TabIndex = 12;
            this.startOnBoot.Text = "Start on boot ?";
            this.startOnBoot.UseVisualStyleBackColor = true;
            // 
            // NotificationBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 360);
            this.Controls.Add(this.startOnBoot);
            this.Controls.Add(this.Group_Server);
            this.Controls.Add(this.Group_Action);
            this.Controls.Add(this.Save_Button);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NotificationBar";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Web Request";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.NotificationBar_Load);
            this.Group_Action.ResumeLayout(false);
            this.Group_Action.PerformLayout();
            this.Group_Server.ResumeLayout(false);
            this.Group_Server.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon BarIcon;
        private System.Windows.Forms.TextBox URL;
        private System.Windows.Forms.TextBox ActionON_Text;
        private System.Windows.Forms.TextBox Token;
        private System.Windows.Forms.Label URL_Label;
        private System.Windows.Forms.Label Token_Label;
        private System.Windows.Forms.Label Label_ActionON;
        private System.Windows.Forms.Label Label_ActionOFF;
        private System.Windows.Forms.TextBox ActionOFF_Text;
        private System.Windows.Forms.Button CheckServer_Button;
        private System.Windows.Forms.Button Save_Button;
        private System.Windows.Forms.GroupBox Group_Action;
        private System.Windows.Forms.GroupBox Group_Server;
        private System.Windows.Forms.TextBox ActionOFFKey_Text;
        private System.Windows.Forms.TextBox ActionONKey_Text;
        private System.Windows.Forms.Label Label_HotKeys;
        private System.Windows.Forms.Button ActionON_Button;
        private System.Windows.Forms.Button ActionOFF_Button;
        private System.Windows.Forms.CheckBox startOnBoot;

    }
}

