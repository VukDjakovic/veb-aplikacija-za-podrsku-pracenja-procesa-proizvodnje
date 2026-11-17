<%@ Page Title="Plan proizvodnje - Unos" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="PlanUnos.aspx.cs" Inherits="KorisnickiInterfejs.PlanUnos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-5">
        <div class="d-flex justify-content-between align-items-center mb-3">
            <h2 class="mb-0">Planiranje proizvodnje</h2>
        </div>
        <hr />

        <asp:UpdatePanel ID="upPorudzbine" runat="server">
            <ContentTemplate>
                <div class="row g-4">
                    <div class="col-lg-7 col-md-12">
                        <div class="card shadow-sm h-100">
                            <div class="card-body">
                                <h4 class="card-title mb-3">Pregled porudžbina</h4>

                                <div class="d-flex flex-wrap align-items-center mb-3">
                                    <asp:Label ID="lblFilter" runat="server" Text="ID porudžbine:" CssClass="mr-2 mb-2" />
                                    <asp:TextBox ID="txtFilterPorudzbina" runat="server" CssClass="form-control mr-2 mb-2" Width="120px" />
                                    <asp:Button ID="btnPretrazi" runat="server" Text="Pretraži" CssClass="btn btn-primary mb-2 mr-2" OnClick="btnPretrazi_Click" />
                                    <asp:Button ID="btnPrikaziSve" runat="server" Text="Prikaži sve" CssClass="btn btn-secondary mb-2" OnClick="btnPrikaziSve_Click" />
                                </div>

                                <div class="table-responsive">
                                    <asp:GridView ID="gvPorudzbine" runat="server" 
                                        CssClass="table table-striped table-hover align-middle"
                                        AutoGenerateColumns="False" AllowPaging="True" PageSize="10"
                                        OnPageIndexChanging="gvPorudzbine_PromenaStrane"
                                        OnSelectedIndexChanged="gvPorudzbine_PromenaIzabranogReda"
                                        DataKeyNames="PorudzbinaID">
                                        <Columns>
                                            <asp:BoundField DataField="PorudzbinaID" HeaderText="ID" />
                                            <asp:BoundField DataField="DatumPorudzbine" HeaderText="Datum" DataFormatString="{0:dd.MM.yyyy}" />
                                            <asp:BoundField DataField="NazivKupca" HeaderText="Kupac" />
                                            <asp:BoundField DataField="NazivProizvoda" HeaderText="Proizvod" />
                                            <asp:BoundField DataField="Kolicina" HeaderText="Količina" />
                                            <asp:CommandField ShowSelectButton="True" SelectText="Odaberi" />
                                        </Columns>
                                    </asp:GridView>
                                </div>

                                <asp:Label ID="lblInfo" runat="server" CssClass="text-muted small" />
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-5 col-md-12">
                        <div class="card shadow-sm h-100">
                            <div class="card-body">
                                <h4 class="card-title mb-3">Unos novog plana</h4>

                                <div class="form-group mb-3">
                                    <asp:Label ID="lblDatum" runat="server" Text="Datum roka izrade:" CssClass="form-label" />
                                    <asp:TextBox ID="txtDatumRokaIzrade" runat="server" CssClass="form-control" TextMode="Date" />
                                </div>

                                <div class="form-group mb-3">
                                    <asp:Label ID="lblPorudzbinaID" runat="server" Text="ID porudžbine:" CssClass="form-label" />
                                    <asp:TextBox ID="txtPorudzbinaID" runat="server" CssClass="form-control" ReadOnly="true" />
                                </div>

                                <div class="form-group mb-4">
                                    <asp:Label ID="lblStatusPlana" runat="server" Text="Status plana:" CssClass="form-label" />
                                    <asp:DropDownList ID="ddlStatusPlana" runat="server" CssClass="form-control">
                                        <asp:ListItem Text="U toku" Value="U toku" />
                                        <asp:ListItem Text="Završen" Value="Završen" />
                                        <asp:ListItem Text="Otkazan" Value="Otkazan" />
                                        <asp:ListItem Text="Pauziran" Value="Pauziran" />
                                    </asp:DropDownList>
                                </div>

                                <asp:Button ID="btnUnesiPlan" runat="server" Text="Sačuvaj plan" CssClass="btn btn-success w-100" OnClick="btnUnesiPlan_Click" />
                                <asp:Label ID="lblInfoPlan" runat="server" CssClass="mt-3 d-block fw-bold" />
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>
