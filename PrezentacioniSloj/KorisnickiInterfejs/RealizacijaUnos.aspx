<%@ Page Title="Unos realizacije" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="RealizacijaUnos.aspx.cs" Inherits="KorisnickiInterfejs.RealizacijaUnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-4">
        <h3>Realizacija proizvodnje</h3>
        <hr />

        <asp:UpdatePanel ID="upMain" runat="server">
            <ContentTemplate>
                <div class="row">
                    <div class="col-lg-8">
                        <h4>Pregled planova proizvodnje</h4>

                        <div class="form-inline mb-3">
                            <asp:Label ID="lblFilter" runat="server" Text="Pretraga (ID):" CssClass="mr-2"></asp:Label>
                            <asp:TextBox ID="txtFilterPlan" runat="server" CssClass="form-control mr-2" Width="150px"></asp:TextBox>
                            <asp:Button ID="btnPretrazi" runat="server" Text="Pretraži" CssClass="btn btn-primary" OnClick="btnPretrazi_Click" />
                            <asp:Button ID="btnPrikaziSve" runat="server" Text="Prikaži sve" CssClass="btn btn-secondary ml-2" OnClick="btnPrikaziSve_Click" />
                        </div>

                        <asp:GridView ID="gvPlanovi" runat="server" CssClass="table table-striped table-bordered"
                            AutoGenerateColumns="False" AllowPaging="True" PageSize="10"
                            OnPageIndexChanging="gvPlanovi_PromenaStrane" 
                            OnSelectedIndexChanged="gvPlanovi_PromenaIzabranogReda"
                            DataKeyNames="PlanID">
                            <Columns>
                                <asp:BoundField DataField="PlanID" HeaderText="Plan ID" />
                                <asp:BoundField DataField="DatumRokaIzrade" HeaderText="Rok izrade" DataFormatString="{0:dd.MM.yyyy}" />
                                <asp:BoundField DataField="PorudzbinaID" HeaderText="Porudžbina" />
                                <asp:BoundField DataField="ProizvodID" HeaderText="ProizvodID"/>
                                <asp:BoundField DataField="NazivProizvoda" HeaderText="Proizvod" />
                                <asp:BoundField DataField="PotrebnaKolicinaProizvoda" HeaderText="Kol. proizvoda" />
                                <asp:BoundField DataField="DeoID" HeaderText="DeoID"/>
                                <asp:BoundField DataField="NazivDela" HeaderText="Deo" />
                                <asp:BoundField DataField="PotrebnaKolicinaDelova" HeaderText="Kol. delova" />
                                <asp:BoundField DataField="StatusPlana" HeaderText="Status" />
                                <asp:CommandField ShowSelectButton="True" SelectText="Odaberi" />
                            </Columns>

                        </asp:GridView>

                        <asp:Label ID="lblInfo" runat="server" CssClass="text-info"></asp:Label>
                    </div>

                    <div class="col-lg-4">
                        <h4>Unos realizacije</h4>

                        <div class="card p-3 shadow-sm">
                            <h5>Realizacija delova</h5>
                            <div class="form-group">
                                <asp:Label ID="lblDeoID" runat="server" Text="ID dela:" />
                                <asp:TextBox ID="txtDeoID" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblKolicinaDelova" runat="server" Text="Realizovana količina:" />
                                <asp:TextBox ID="txtKolicinaDelova" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblDatumDelova" runat="server" Text="Datum realizacije:" />
                                <asp:TextBox ID="txtDatumDelova" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblSektorDelova" runat="server" Text="Sektor:" />
                                <asp:DropDownList ID="ddlSektorDelova" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <asp:Button ID="Button1" runat="server" Text="Sačuvaj realizaciju delova" CssClass="btn btn-primary w-100" OnClick="btnUnesiRealizacijuDelova_Click" />
                            <asp:Label ID="lblInfoDelovi" runat="server" CssClass="text-info mt-2"></asp:Label>
                        </div>

                        <div class="card p-3 mb-4 shadow-sm">
                            <h5>Realizacija proizvoda</h5>
                            <div class="form-group">
                                <asp:Label ID="lblProizvodID" runat="server" Text="ID proizvoda:" />
                                <asp:TextBox ID="txtProizvodID" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblKolicinaProizvoda" runat="server" Text="Realizovana količina:" />
                                <asp:TextBox ID="txtKolicinaProizvoda" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblDatumProizvoda" runat="server" Text="Datum realizacije:" />
                                <asp:TextBox ID="txtDatumProizvoda" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:Label ID="lblSektorProizvoda" runat="server" Text="Sektor:" />
                                <asp:DropDownList ID="ddlSektorProizvoda" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <asp:Button ID="btnUnesiRealizacijuProizvoda" runat="server" Text="Sačuvaj realizaciju proizvoda" CssClass="btn btn-success w-100" OnClick="btnUnesiRealizacijuProizvoda_Click" />
                            <asp:Label ID="lblInfoProizvod" runat="server" CssClass="text-info mt-2"></asp:Label>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>
