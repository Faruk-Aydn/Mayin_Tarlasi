namespace mayin_tarlası
{
    partial class Form1
    {
        /// <summary>
        /// Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        /// <param name="disposing">yönetilen kaynakları serbest bırakmak için true; aksi halde false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gereken yöntem - bu yöntemin 
        /// içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 400); // Form başlangıç boyutu
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle; // Sabit boyut
            this.MaximizeBox = false; // Maksimize düğmesini devre dışı bırak
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen; // Ekranın ortasında başlat
            this.Text = "Mayın Tarlası"; // Başlık
            this.ResumeLayout(false);
        }

        #endregion
    }
}