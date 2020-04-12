
using OrderApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderForm {
  public partial class OrderMainForm : Form {
    OrderService orderService;
    BindingSource fieldsBS = new BindingSource();
    public String Keyword { get; set; }

    public OrderMainForm() {
      InitializeComponent();
      orderService = new OrderService();
      Order order = new Order(1, new Customer("1", "张三"), new List<OrderItem>());
      order.AddItem(new OrderItem(1, new Goods("1", "apple", 100.0), 7));
      orderService.AddOrder(order);
      Order order2 = new Order(2, new Customer("2", "李四"), new List<OrderItem>());
      order2.AddItem(new OrderItem(1, new Goods("2", "egg", 200.0), 10));
      orderService.AddOrder(order2);
      orderBindingSource.DataSource = orderService.Orders;
      cbField.SelectedIndex = 0;
      txtValue.DataBindings.Add("Text", this, "Keyword");
    }

    private void btnAdd_Click(object sender, EventArgs e) {
      OrderFormEdit form2 = new OrderFormEdit(new Order());
      if (form2.ShowDialog() == DialogResult.OK) {
        orderService.AddOrder(form2.CurrentOrder);
        UpdateAll();
      }
    }

    private void UpdateAll() {
      orderBindingSource.DataSource = orderService.Orders;
      orderBindingSource.ResetBindings(false);
    }

    private void btnModify_Click(object sender, EventArgs e) {
      EditOrder();
    }
    private void dbvOrders_DoubleClick(object sender, EventArgs e) {
      EditOrder();
    }
    private void EditOrder() {
      Order order = orderBindingSource.Current as Order;
      if (order == null) {
        MessageBox.Show("请选择一个订单进行修改");
        return;
      }
      OrderFormEdit form2 = new OrderFormEdit(order, true);
      if (form2.ShowDialog() == DialogResult.OK) {
        orderService.UpdateOrder(form2.CurrentOrder);
        UpdateAll();
      }
    }

    private void btnDelete_Click(object sender, EventArgs e) {
      Order order = orderBindingSource.Current as Order;
      if (order == null) {
        MessageBox.Show("请选择一个订单进行删除");
        return;
      }
      orderService.RemoveOrder(order.OrderId);
      UpdateAll();
    }

    private void btnExport_Click(object sender, EventArgs e) {
      DialogResult result = saveFileDialog1.ShowDialog();
      if (result.Equals(DialogResult.OK)) {
        String fileName = saveFileDialog1.FileName;
        orderService.Export(fileName);
      }
    }

    private void btnImport_Click(object sender, EventArgs e) {
      DialogResult result = openFileDialog1.ShowDialog();
      if (result.Equals(DialogResult.OK)) {
        String fileName = openFileDialog1.FileName;
        orderService.Import(fileName);
        UpdateAll();
      }
    }

    private void btnQuery_Click(object sender, EventArgs e) {
      switch (cbField.SelectedIndex) {
        case 0:
          orderBindingSource.DataSource =orderService.Orders;
          break;
        case 1:
          int.TryParse(Keyword, out int id);
          Order order = orderService.GetOrder((uint)id);
          List<Order> result = new List<Order>();
          if (order != null) result.Add(order);
          orderBindingSource.DataSource = result;
          break;
        case 2:
          orderBindingSource.DataSource =orderService.QueryOrdersByCustomerName(Keyword);
          break;
        case 3:
          orderBindingSource.DataSource =orderService.QueryOrdersByGoodsName(Keyword);
          break;
        case 4:
          float.TryParse(Keyword,  out float totalPrice);
          orderBindingSource.DataSource =
                 orderService.QueryByTotalAmount(totalPrice);
          break;
      }
      orderBindingSource.ResetBindings(true);

    }

 
  }
}
