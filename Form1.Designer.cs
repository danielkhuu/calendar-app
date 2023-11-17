namespace Calendar
{
    partial class TaskScheduler
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskScheduler));
            this.TaskList = new System.Windows.Forms.ListView();
            this.CreateTaskBtn = new System.Windows.Forms.Button();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.TaskDescTXT = new System.Windows.Forms.TextBox();
            this.TaskDescLABEL = new System.Windows.Forms.Label();
            this.DateMade = new System.Windows.Forms.DateTimePicker();
            this.DateMadeLABEL = new System.Windows.Forms.Label();
            this.DeleteTaskBtn = new System.Windows.Forms.Button();
            this.ModifyBoxTXT = new System.Windows.Forms.TextBox();
            this.ModifyBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TaskList
            // 
            resources.ApplyResources(this.TaskList, "TaskList");
            this.TaskList.HideSelection = false;
            this.TaskList.Name = "TaskList";
            this.TaskList.UseCompatibleStateImageBehavior = false;
            this.TaskList.SelectedIndexChanged += new System.EventHandler(this.TaskList_SelectedIndexChanged);
            // 
            // CreateTaskBtn
            // 
            resources.ApplyResources(this.CreateTaskBtn, "CreateTaskBtn");
            this.CreateTaskBtn.Name = "CreateTaskBtn";
            this.CreateTaskBtn.UseVisualStyleBackColor = true;
            this.CreateTaskBtn.Click += new System.EventHandler(this.CreateTaskBtn_Click);
            // 
            // ExitBtn
            // 
            resources.ApplyResources(this.ExitBtn, "ExitBtn");
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // TaskDescTXT
            // 
            resources.ApplyResources(this.TaskDescTXT, "TaskDescTXT");
            this.TaskDescTXT.Name = "TaskDescTXT";
            // 
            // TaskDescLABEL
            // 
            resources.ApplyResources(this.TaskDescLABEL, "TaskDescLABEL");
            this.TaskDescLABEL.Name = "TaskDescLABEL";
            // 
            // DateMade
            // 
            resources.ApplyResources(this.DateMade, "DateMade");
            this.DateMade.Name = "DateMade";
            // 
            // DateMadeLABEL
            // 
            resources.ApplyResources(this.DateMadeLABEL, "DateMadeLABEL");
            this.DateMadeLABEL.Name = "DateMadeLABEL";
            // 
            // DeleteTaskBtn
            // 
            resources.ApplyResources(this.DeleteTaskBtn, "DeleteTaskBtn");
            this.DeleteTaskBtn.Name = "DeleteTaskBtn";
            this.DeleteTaskBtn.UseVisualStyleBackColor = true;
            this.DeleteTaskBtn.Click += new System.EventHandler(this.DeleteTaskBtn_Click);
            // 
            // ModifyBoxTXT
            // 
            resources.ApplyResources(this.ModifyBoxTXT, "ModifyBoxTXT");
            this.ModifyBoxTXT.Name = "ModifyBoxTXT";
            // 
            // ModifyBtn
            // 
            resources.ApplyResources(this.ModifyBtn, "ModifyBtn");
            this.ModifyBtn.Name = "ModifyBtn";
            this.ModifyBtn.UseVisualStyleBackColor = true;
            this.ModifyBtn.Click += new System.EventHandler(this.ModifyBtn_Click);
            // 
            // TaskScheduler
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.ModifyBtn);
            this.Controls.Add(this.ModifyBoxTXT);
            this.Controls.Add(this.DeleteTaskBtn);
            this.Controls.Add(this.DateMadeLABEL);
            this.Controls.Add(this.DateMade);
            this.Controls.Add(this.TaskDescLABEL);
            this.Controls.Add(this.TaskDescTXT);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.CreateTaskBtn);
            this.Controls.Add(this.TaskList);
            this.DoubleBuffered = true;
            this.Name = "TaskScheduler";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView TaskList;
        private System.Windows.Forms.Button CreateTaskBtn;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.TextBox TaskDescTXT;
        private System.Windows.Forms.Label TaskDescLABEL;
        private System.Windows.Forms.DateTimePicker DateMade;
        private System.Windows.Forms.Label DateMadeLABEL;
        private System.Windows.Forms.Button DeleteTaskBtn;
        private System.Windows.Forms.TextBox ModifyBoxTXT;
        private System.Windows.Forms.Button ModifyBtn;
    }
}

