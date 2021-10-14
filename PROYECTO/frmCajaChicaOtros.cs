using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PROYECTO_DAO;
using Entidades;

namespace PROYECTO
{
    public partial class frmCajaChicaOtros : Form
    {

        private static frmCajaChicaOtros instance = null;
        private CajaChicaDAO oChicaDAO = null;
        private CajaChica oChica = null;
        private CajaChicaDetalle oChicaDetalle = null;
        private CajaChicaDetalleDAO oChicaDetalleDAO = null;
        private ConexionDAO oConexion = null;
        private int timer = 0, indice = 0;
        private char moned = '¢';
        private String codigo = "pro_cajachicaotros", descripcion = "Administracion de movimientos de caja chica.", modulo = "Procesos";
        private String txtMonedas1 = "CRC";
        public String Modulo
        {
            get { return modulo; }
            set { modulo = value; }
        }

        public String Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public String Codigo
        {
            get { return codigo; }
            set { codigo = value; }
        }

        private frmCajaChicaOtros()
        {
            InitializeComponent();
        }

        public static frmCajaChicaOtros getInstance()
        {
            if (instance == null)
                instance = new frmCajaChicaOtros();
            return instance;
        }

        private void frmCajaChicaOtros_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (btnGuardar1.Enabled || btnGuardar2.Enabled || btnGuardar3.Enabled)
            {
                if (MessageBox.Show("Advertencia:\nNo se han Guardado los Cambios.\n ¿Desea Continuar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    frmCajaChica oCaja = frmCajaChica.getInstance();
                    oCaja.MdiParent = this.MdiParent;
                    oCaja.Show();
                    this.Close();
                }
            }
            else
            {
                frmCajaChica oCaja = frmCajaChica.getInstance();
                oCaja.MdiParent = this.MdiParent;
                oCaja.Show();
                this.Close();
            }

        }

        private void frmCajaChicaOtros_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
        
        private void LlenarDatos()
        {
            try
            {
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Clave, PROYECTO.Properties.Settings.Default.Servidor);
                oConexion.cerrarConexion();
                oConexion.cerrarConexion(); if (oConexion.abrirConexion())
                {
                    oChicaDAO = new CajaChicaDAO();
                    lblCajaAbierta1.Text = oChicaDAO.Caja(PROYECTO.Properties.Settings.Default.Usuario, PROYECTO.Properties.Settings.Default.No_cia).Tables[0].Rows[0].ItemArray[0].ToString();
                    lblCajaAbierta2.Text = lblCajaAbierta1.Text;
                    lblCajaAbierta3.Text = lblCajaAbierta1.Text;
                    lblFechaApertura1.Text = oChicaDAO.FechaAperturaCaja(lblCajaAbierta1.Text, PROYECTO.Properties.Settings.Default.Usuario, PROYECTO.Properties.Settings.Default.No_cia).ToShortDateString();
                    lblFechaApertura2.Text = lblFechaApertura1.Text;
                    lblFechaApertura3.Text = lblFechaApertura1.Text;
                    DataTable oTabla = oChicaDAO.Consultar(PROYECTO.Properties.Settings.Default.Usuario, PROYECTO.Properties.Settings.Default.No_cia).Tables[0];
                    txtMonedas1 = oTabla.Rows[0].ItemArray[4].ToString();
                    if (txtMonedas1.Equals("CRC"))
                        moned = '¢';
                    else if (txtMonedas1.Equals("USD"))
                        moned = '$';
                    txtSaldoActual1.Text = moned + " " + double.Parse(oTabla.Rows[0].ItemArray[3].ToString()).ToString("###,###,##0.##");
                    txtSaldoActual2.Text = txtSaldoActual1.Text;
                    txtSaldoActual3.Text = txtSaldoActual1.Text;
                    txtMontoActual.Text = moned + " " + double.Parse(oTabla.Rows[0].ItemArray[2].ToString()).ToString("###,###,##0.##");
                    indice = int.Parse(oTabla.Rows[0].ItemArray[5].ToString());

                    if (oChicaDAO.Error())
                        MessageBox.Show("Error al cargar la Caja Chica:\n" + oChicaDAO.DescError(), "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    oConexion.cerrarConexion();
                }
                else
                    MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos esten correctos");

            }
            catch (Exception ex)
            {
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer++;
            if (timer == 1)
            {
                timer1.Stop();
                LlenarDatos();
            }
        }

        private Boolean evaluar1()
        {
            Boolean val = true;
            if ( txtMontoAumentar1.Text.Trim().Equals("") || txtDoc1.Text.Trim().Equals("") || txtJustificacion1.Text.Trim().Equals(""))
                val = false;
            return val;
        }

        private Boolean evaluar2()
        {
            Boolean val = true;
            if (txtMontoAumentar2.Text.Trim().Equals("") || txtDoc2.Text.Trim().Equals("") || txtJustificacion2.Text.Trim().Equals(""))
                val = false;
            return val;
        }

        private Boolean evaluar3()
        {
            Boolean val = true;
            if (txtMontoAumentar3.Text.Trim().Equals("") || txtDoc3.Text.Trim().Equals("") || txtJustificacion3.Text.Trim().Equals(""))
                val = false;
            return val;
        }

        private void txtMontoAumentar_Leave(object sender, EventArgs e)
        {
            oConexion.cerrarConexion();
            oConexion.cerrarConexion(); oConexion.abrirConexion();
            oChicaDAO = new CajaChicaDAO();
            txtSaldoActual1.Text = moned + " " + oChicaDAO.Consultar(PROYECTO.Properties.Settings.Default.Usuario, PROYECTO.Properties.Settings.Default.No_cia).Tables[0].Rows[0].ItemArray[3].ToString();
            oConexion.cerrarConexion();
            if (txtMontoAumentar1.Text.Trim().Equals("") || txtMontoAumentar1.Text.Trim().Equals("."))
                txtMontoAumentar1.Text = "0";
            string monto = "";
            for (int x = 0; x < txtMontoAumentar1.Text.Length; x++)
            {
                if (!txtMontoAumentar1.Text[x].Equals(' '))
                    monto += txtMontoAumentar1.Text[x];
            }
            txtMontoAumentar1.Text = moned + " " + double.Parse(monto).ToString("###,###,##0.##");

        }

        private void txtMontoAumentar_Enter(object sender, EventArgs e)
        {
            string monto = txtMontoAumentar1.Text;
            if (txtMontoAumentar1.ReadOnly == false)
            {
                txtMontoAumentar1.Text = double.Parse(monto.Substring(1)).ToString("#########");

            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
            btnGuardar1.Enabled = false;
            Limpiar();
            LlenarDatos();
        }

        private void Guardar()
        {
            try
            {
                if (evaluar1())
                {
                    oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Clave, PROYECTO.Properties.Settings.Default.Servidor);
                    oConexion.cerrarConexion();
                    oConexion.cerrarConexion(); if (oConexion.abrirConexion())
                    {
                        oChica = new CajaChica();
                        oChicaDAO = new CajaChicaDAO();
                        txtSaldoActual1.Text = moned + " " + oChicaDAO.Consultar(PROYECTO.Properties.Settings.Default.Usuario, PROYECTO.Properties.Settings.Default.No_cia).Tables[0].Rows[0].ItemArray[3].ToString();
                        oChica.Linea = indice;
                        oChica.Monto = double.Parse(txtMontoActual.Text.Substring(1)) + double.Parse(txtMontoAumentar1.Text.Substring(1));
                        oChica.Saldo = double.Parse(txtMontoAumentar1.Text.Substring(1)) + double.Parse(txtSaldoActual1.Text.Substring(1));
                        oChicaDAO.ActualizarMonto(oChica, PROYECTO.Properties.Settings.Default.No_cia);
                        oChicaDAO.ActualizarSaldo(oChica, PROYECTO.Properties.Settings.Default.No_cia);
                        if (oChicaDAO.Error())
                        {
                            MessageBox.Show("Error al Crear Aumenta en Caja Chica:\n" + oChicaDAO.DescError(), "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
     MessageBox.Show("Aumento de Caja Creado Correctamente!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        oConexion.cerrarConexion();
                        CrearMovimiento();
                   

                    }
                    else
                    {
                        MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos esten correctos", "Error de Conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Advertencia:\nFaltan Datos que Completar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void Guardar2()
        {
            try
            {
                if (evaluar2())
                {
                    oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Clave, PROYECTO.Properties.Settings.Default.Servidor);
                    oConexion.cerrarConexion();
                    oConexion.cerrarConexion(); if (oConexion.abrirConexion())
                    {
                        oChica = new CajaChica();
                        oChicaDAO = new CajaChicaDAO();
                        txtSaldoActual2.Text = moned + " " + oChicaDAO.Consultar(PROYECTO.Properties.Settings.Default.Usuario, PROYECTO.Properties.Settings.Default.No_cia).Tables[0].Rows[0].ItemArray[3].ToString();
                        oChica.Linea = indice;
                        oChica.Saldo = double.Parse(txtSaldoActual2.Text.Substring(1)) - double.Parse(txtMontoAumentar2.Text.Substring(1));
                        oChicaDAO.ActualizarSaldo(oChica, PROYECTO.Properties.Settings.Default.No_cia);
                        if (oChicaDAO.Error())
                            MessageBox.Show("Error al crear Nota de Débito:\n" + oChicaDAO.DescError(), "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
MessageBox.Show("Nota de Débito Creada Correctamente!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        oConexion.cerrarConexion();
                        CrearMovimiento2();
                        

                    }
                    else
                    {
                        MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos esten correctos", "Error de Conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Advertencia:\nFaltan Datos que Completar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void Guardar3()
        {
            try
            {
                if (evaluar3())
                {
                    oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Clave, PROYECTO.Properties.Settings.Default.Servidor);
                    oConexion.cerrarConexion();
                    oConexion.cerrarConexion(); if (oConexion.abrirConexion())
                    {
                        oChica = new CajaChica();
                        oChicaDAO = new CajaChicaDAO();
                        txtSaldoActual3.Text = moned + " " + oChicaDAO.Consultar(PROYECTO.Properties.Settings.Default.Usuario, PROYECTO.Properties.Settings.Default.No_cia).Tables[0].Rows[0].ItemArray[3].ToString();
                        oChica.Linea = indice;
                        oChica.Saldo = double.Parse(txtMontoAumentar3.Text.Substring(1)) + double.Parse(txtSaldoActual3.Text.Substring(1));
                        oChicaDAO.ActualizarSaldo(oChica, PROYECTO.Properties.Settings.Default.No_cia);
                        if (oChicaDAO.Error())
                        {
                            MessageBox.Show("Error al Crear Nota de Crédito:\n" + oChicaDAO.DescError(), "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }else
 MessageBox.Show("Nota de Crédito Creada Correctamente!!", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        oConexion.cerrarConexion();
                        CrearMovimiento3();           

                    }
                    else
                        MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos esten correctos", "Error de Conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else
                    MessageBox.Show("Advertencia:\nFaltan Datos que Completar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            catch (Exception ex)
            {
            }
        }

        private void CrearMovimiento()
        {
            try
            {
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Clave, PROYECTO.Properties.Settings.Default.Servidor);
                oConexion.cerrarConexion();
                oConexion.cerrarConexion(); if (oConexion.abrirConexion())
                {
                    oChicaDetalle = new CajaChicaDetalle();
                    oChicaDetalleDAO = new CajaChicaDetalleDAO();
                    oChicaDetalle.Caja = indice;
                    oChicaDetalle.Movimiento = "AUMENTO EN CAJA";
                    oChicaDetalle.Credito = double.Parse(txtMontoAumentar1.Text.Substring(1));
                    oChicaDetalle.Debito = 0;
                    oChicaDetalle.Empleado = "CAJA CHICA";
                    oChicaDetalle.Documento = txtDoc1.Text;
                    oChicaDetalle.Usuario = PROYECTO.Properties.Settings.Default.Usuario;
                    oChicaDetalle.TipoMovimiento = "AUMENTO";
                    oChicaDetalle.Justificacion = txtJustificacion1.Text;
                    oChicaDetalleDAO.Insertar(oChicaDetalle, PROYECTO.Properties.Settings.Default.No_cia);
                    if (oChicaDetalleDAO.Error())
                        MessageBox.Show("Error al Guardar Movimiento de Caja Chica:\n" + oChicaDetalleDAO.DescError(), "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    oConexion.cerrarConexion();
                }
                else
                    MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos esten correctos");

            }
            catch (Exception ex)
            {
            }
        }

        private void CrearMovimiento2()
        {
            try
            {
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Clave, PROYECTO.Properties.Settings.Default.Servidor);
                oConexion.cerrarConexion();
                oConexion.cerrarConexion(); if (oConexion.abrirConexion())
                {
                    oChicaDetalle = new CajaChicaDetalle();
                    oChicaDetalleDAO = new CajaChicaDetalleDAO();
                    oChicaDetalle.Caja = indice;
                    oChicaDetalle.Movimiento = "NOTA DE DÉBITO";
                    oChicaDetalle.Credito = 0;
                    oChicaDetalle.Debito = double.Parse(txtMontoAumentar2.Text.Substring(1));
                    oChicaDetalle.Empleado = "CAJA CHICA";
                    oChicaDetalle.Documento = txtDoc2.Text;
                    oChicaDetalle.Usuario = PROYECTO.Properties.Settings.Default.Usuario;
                    oChicaDetalle.TipoMovimiento = "NOTAS DE DÉBITO";
                    oChicaDetalle.Justificacion = txtJustificacion2.Text;
        
                    oChicaDetalleDAO.Insertar(oChicaDetalle, PROYECTO.Properties.Settings.Default.No_cia);
                    if (oChicaDetalleDAO.Error())
                        MessageBox.Show("Error al Guardar Movimiento de Caja Chica:\n" + oChicaDetalleDAO.DescError(), "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    oConexion.cerrarConexion();
                }
                else
                    MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos esten correctos");

            }
            catch (Exception ex)
            {
            }
        }

        private void CrearMovimiento3()
        {
            try
            {
                oConexion = new ConexionDAO(PROYECTO.Properties.Settings.Default.UsuarioBD, PROYECTO.Properties.Settings.Default.Clave, PROYECTO.Properties.Settings.Default.Servidor);
                oConexion.cerrarConexion();
                oConexion.cerrarConexion(); if (oConexion.abrirConexion())
                {
                    oChicaDetalle = new CajaChicaDetalle();
                    oChicaDetalleDAO = new CajaChicaDetalleDAO();
                    oChicaDetalle.Caja = indice;
                    oChicaDetalle.Movimiento = "NOTA DE CRÉDITO";
                    oChicaDetalle.Credito = double.Parse(txtMontoAumentar3.Text.Substring(1));
                    oChicaDetalle.Debito = 0;
                    oChicaDetalle.Empleado = "CAJA CHICA";
                    oChicaDetalle.Documento = txtDoc3.Text;
                    oChicaDetalle.Usuario = PROYECTO.Properties.Settings.Default.Usuario;
                    oChicaDetalle.TipoMovimiento = "NOTAS DE CRÉDITO";
                    oChicaDetalle.Justificacion = txtJustificacion3.Text;
  
                    oChicaDetalleDAO.Insertar(oChicaDetalle, PROYECTO.Properties.Settings.Default.No_cia);
                    if (oChicaDetalleDAO.Error())
                        MessageBox.Show("Error al Guardar Movimiento de Caja Chica:\n" + oChicaDetalleDAO.DescError(), "Error de Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    oConexion.cerrarConexion();
                }
                else
                    MessageBox.Show("Error al conectarse con la base de datos\nVerifique que los datos esten correctos");

            }
            catch (Exception ex)
            {
            }
        }
        
        private void txtMontoAumentar_KeyUp(object sender, KeyEventArgs e)
        {
            string monto = "";
            for (int x = 0; x < txtMontoAumentar1.Text.Length; x++)
            {
                if (!txtMontoAumentar1.Text[x].Equals(' '))
                    monto += txtMontoAumentar1.Text[x];
            }
            if (!monto.Equals(""))
            {
                if (double.Parse(monto) > 0)
                    btnGuardar1.Enabled = true;
                else
                    btnGuardar1.Enabled = false;
            }
        }

        private void btnGuardar3_Click(object sender, EventArgs e)
        {
            Guardar3();
            btnGuardar3.Enabled = false;
            Limpiar();
            LlenarDatos();
        }

        private void Limpiar()
        {
            txtDoc1.Clear();
            txtMontoAumentar1.Clear();
            txtJustificacion1.Clear();
        }
        
        private void btnGuardar2_Click(object sender, EventArgs e)
        {
            Guardar2();
            btnGuardar2.Enabled = false;
            Limpiar();
            LlenarDatos();
        }

        private void txtMontoAumentar2_Enter(object sender, EventArgs e)
        {
            string monto = txtMontoAumentar2.Text;
            if (txtMontoAumentar2.ReadOnly == false)
            {
                txtMontoAumentar2.Text = double.Parse(monto.Substring(1)).ToString("###,###,##0.##");

            }
        }

        private void txtMontoAumentar2_KeyUp(object sender, KeyEventArgs e)
        {
            string monto = "";
            for (int x = 0; x < txtMontoAumentar2.Text.Length; x++)
            {
                if (!txtMontoAumentar2.Text[x].Equals(' '))
                    monto += txtMontoAumentar2.Text[x];
            }
            if (!monto.Equals(""))
            {
                if (double.Parse(monto) > 0 && double.Parse(monto) <= double.Parse(txtSaldoActual2.Text.Substring(1)))
                    btnGuardar2.Enabled = true;
                else
                    btnGuardar2.Enabled = false;
            }
        }

        private void txtMontoAumentar2_Leave(object sender, EventArgs e)
        {
            oConexion.cerrarConexion();
            oConexion.cerrarConexion(); oConexion.abrirConexion();
            oChicaDAO = new CajaChicaDAO();
            txtSaldoActual2.Text = moned + " " + oChicaDAO.Consultar(PROYECTO.Properties.Settings.Default.Usuario, PROYECTO.Properties.Settings.Default.No_cia).Tables[0].Rows[0].ItemArray[3].ToString();
            oConexion.cerrarConexion();

            if (txtMontoAumentar2.Text.Trim().Equals("") || txtMontoAumentar2.Text.Trim().Equals("."))
                txtMontoAumentar2.Text = "0";
            string monto = "";
            for (int x = 0; x < txtMontoAumentar2.Text.Length; x++)
            {
                if (!txtMontoAumentar2.Text[x].Equals(' '))
                    monto += txtMontoAumentar2.Text[x];
            }
            txtMontoAumentar2.Text = moned + " " + double.Parse(monto).ToString("###,###,##0.##");
            if (double.Parse(monto) > double.Parse(txtSaldoActual2.Text.Substring(1)))
            {
                MessageBox.Show("El monto no puede ser mayor al saldo");
                txtMontoAumentar2.Text = txtSaldoActual2.Text;
            }
            if (!monto.Equals(""))
            {
                if (double.Parse(monto) > 0 && double.Parse(txtMontoAumentar2.Text.Substring(1)) <= double.Parse(txtSaldoActual2.Text.Substring(1)))
                    btnGuardar2.Enabled = true;
                else
                    btnGuardar2.Enabled = false;
            }
        }

        private void txtMontoAumentar3_Enter(object sender, EventArgs e)
        {
            string monto = txtMontoAumentar3.Text;
            if (txtMontoAumentar3.ReadOnly == false)
            {
                txtMontoAumentar3.Text = double.Parse(monto.Substring(1)).ToString("###,###,##0.##");

            }
        }

        private void txtMontoAumentar3_KeyUp(object sender, KeyEventArgs e)
        {
            string monto = "";
            for (int x = 0; x < txtMontoAumentar3.Text.Length; x++)
            {
                if (!txtMontoAumentar3.Text[x].Equals(' '))
                    monto += txtMontoAumentar3.Text[x];
            }
            if (!monto.Equals(""))
            {
                if (double.Parse(monto) > 0)
                    btnGuardar3.Enabled = true;
                else
                    btnGuardar3.Enabled = false;
            }
        }

        private void txtMontoAumentar3_Leave(object sender, EventArgs e)
        {
            oConexion.cerrarConexion();
            oConexion.cerrarConexion(); oConexion.abrirConexion();
            oChicaDAO = new CajaChicaDAO();
            txtSaldoActual3.Text = moned + " " + oChicaDAO.Consultar(PROYECTO.Properties.Settings.Default.Usuario, PROYECTO.Properties.Settings.Default.No_cia).Tables[0].Rows[0].ItemArray[3].ToString();
            oConexion.cerrarConexion();
            if (txtMontoAumentar3.Text.Trim().Equals("") || txtMontoAumentar3.Text.Trim().Equals("."))
                txtMontoAumentar3.Text = "0";
            string monto = "";
            for (int x = 0; x < txtMontoAumentar3.Text.Length; x++)
            {
                if (!txtMontoAumentar3.Text[x].Equals(' '))
                    monto += txtMontoAumentar3.Text[x];
            }
            txtMontoAumentar3.Text = moned + " " + double.Parse(monto).ToString("###,###,##0.##");
        }

        private void txtMontoAumentar1_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (txtMontoAumentar1.ReadOnly == false)
                {
                    int puntos = 0;
                    for (int i = 0; i < txtMontoAumentar1.Text.Length; i++)
                    {
                        if (txtMontoAumentar1.Text[i].Equals('.'))
                            puntos++;
                    }

                    if (Char.IsSeparator(e.KeyChar) || Char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || e.KeyChar.Equals(',') || e.KeyChar.Equals('*') || e.KeyChar.Equals('/') || e.KeyChar.Equals('-') || Char.IsPunctuation(e.KeyChar) && e.KeyChar.Equals('.') && puntos > 0)
                        e.Handled = true;
                }
                if (!txtMontoAumentar1.Text.Equals(""))
                {
                    if (double.Parse(txtMontoAumentar1.Text) > 0)
                        btnGuardar1.Enabled = true;
                    else
                        btnGuardar1.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                txtMontoAumentar1.Text = moned + " 0";                
            }
        }

        private void txtMontoAumentar2_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (txtMontoAumentar2.ReadOnly == false)
                {
                    int puntos = 0;
                    for (int i = 0; i < txtMontoAumentar2.Text.Length; i++)
                    {
                        if (txtMontoAumentar2.Text[i].Equals('.'))
                            puntos++;
                    }

                    if (Char.IsSeparator(e.KeyChar) || Char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || e.KeyChar.Equals(',') || e.KeyChar.Equals('*') || e.KeyChar.Equals('/') || e.KeyChar.Equals('-') || Char.IsPunctuation(e.KeyChar) && e.KeyChar.Equals('.') && puntos > 0)
                        e.Handled = true;
                }
                if (!txtMontoAumentar2.Text.Equals(""))
                {
                    if (double.Parse(txtMontoAumentar2.Text) > 0)
                        btnGuardar2.Enabled = true;
                    else
                        btnGuardar2.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                txtMontoAumentar2.Text = moned + " 0";
            }
        }

        private void txtMontoAumentar3_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (txtMontoAumentar3.ReadOnly == false)
                {
                    int puntos = 0;
                    for (int i = 0; i < txtMontoAumentar3.Text.Length; i++)
                    {
                        if (txtMontoAumentar3.Text[i].Equals('.'))
                            puntos++;
                    }

                    if (Char.IsSeparator(e.KeyChar) || Char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || e.KeyChar.Equals(',') || e.KeyChar.Equals('*') || e.KeyChar.Equals('/') || e.KeyChar.Equals('-') || Char.IsPunctuation(e.KeyChar) && e.KeyChar.Equals('.') && puntos > 0)
                        e.Handled = true;
                }
                if (!txtMontoAumentar3.Text.Equals(""))
                {
                    if (double.Parse(txtMontoAumentar3.Text) > 0)
                        btnGuardar3.Enabled = true;
                    else
                        btnGuardar3.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                txtMontoAumentar3.Text = moned + " 0";
            }
        }


    }
}