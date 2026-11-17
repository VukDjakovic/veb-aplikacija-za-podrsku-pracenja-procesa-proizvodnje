<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlanPregled.aspx.cs" Inherits="KorisnickiInterfejs.PlanPregled" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Pregled planova proizvodnje</h3>

    <div class="form-inline mb-3">
        <asp:Label ID="lblFilter" runat="server" Text="Pretraga (ID):" CssClass="mr-2"></asp:Label>
        <asp:TextBox ID="txtFilterPlan" runat="server" CssClass="form-control mr-2" Width="150px"></asp:TextBox>
        <asp:Button ID="btnPretrazi" runat="server" Text="Pretraži" CssClass="btn btn-primary" OnClick="btnPretrazi_Click" />
        <asp:Button ID="btnPrikaziSve" runat="server" Text="Prikaži sve" CssClass="btn btn-secondary ml-2" OnClick="btnPrikaziSve_Click" />
    </div>

    <asp:GridView ID="gvPlanovi" runat="server" CssClass="table table-striped table-bordered"
        AutoGenerateColumns="False" AllowPaging="True" PageSize="10"
        DataKeyNames="PlanID"
        OnPageIndexChanging="gvPlanovi_PromenaStrane"
        OnRowEditing="gvPlanovi_IzmenaReda"
        OnRowCancelingEdit="gvPlanovi_OtkazIzmene"
        OnRowUpdating="gvPlanovi_AzuriranjeReda"
        OnRowDeleting="gvPlanovi_BrisanjeReda">

        <Columns>
            <asp:BoundField DataField="PlanID" HeaderText="Plan ID" ReadOnly="True" />
            <asp:TemplateField HeaderText="Rok izrade">
                    <ItemTemplate>
                        <%# Eval("DatumRokaIzrade", "{0:dd.MM.yyyy}") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtDatum" runat="server" Text='<%# Bind("DatumRokaIzrade", "{0:yyyy-MM-dd}") %>' TextMode="Date" CssClass="form-control" />
                    </EditItemTemplate>
                </asp:TemplateField>
            <asp:BoundField DataField="PorudzbinaID" HeaderText="Porudžbina" ReadOnly="True" />
            <asp:BoundField DataField="ProizvodID" HeaderText="ProizvodID" ReadOnly="True"/>
            <asp:BoundField DataField="NazivProizvoda" HeaderText="Proizvod" ReadOnly="True"/>
            <asp:BoundField DataField="PotrebnaKolicinaProizvoda" HeaderText="Kol. proizvoda" ReadOnly="True"/>
            <asp:BoundField DataField="DeoID" HeaderText="DeoID" ReadOnly="True"/>
            <asp:BoundField DataField="NazivDela" HeaderText="Deo" ReadOnly="True"/>
            <asp:BoundField DataField="PotrebnaKolicinaDelova" HeaderText="Kol. delova" ReadOnly="True"/>
            <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <%# Eval("StatusPlana") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                            <asp:ListItem Text="U toku" Value="U toku" />
                            <asp:ListItem Text="Završen" Value="Zavrsen" />
                            <asp:ListItem Text="Otkazan" Value="Otkazan" />
                            <asp:ListItem Text="Pauziran" Value="Pauziran" />
                        </asp:DropDownList>
                    </EditItemTemplate>
                </asp:TemplateField>
            
            <asp:CommandField ShowEditButton="True" EditText="Izmeni" CancelText="Otkaži" UpdateText="Sačuvaj" />
            <asp:CommandField ShowDeleteButton="True" DeleteText="Obriši" />
        </Columns>
    </asp:GridView>

    <asp:Label ID="lblInfo" runat="server" CssClass="text-info"></asp:Label>
</asp:Content>