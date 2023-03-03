using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VTMES3_RE.View.ProductInfo
{
    public partial class frmItemMaster : DevExpress.XtraEditors.XtraForm
    {
        public frmItemMaster()
        {
            InitializeComponent();
        }

        private void frmItemMaster_Load(object sender, EventArgs e)
        {
            // TODO: 이 코드는 데이터를 'iFRYDataSet.MES2_ITEM_MASTER' 테이블에 로드합니다. 필요 시 이 코드를 이동하거나 제거할 수 있습니다.
            this.mES2_ITEM_MASTERTableAdapter.Fill(this.iFRYDataSet.MES2_ITEM_MASTER);

        }
    }
}