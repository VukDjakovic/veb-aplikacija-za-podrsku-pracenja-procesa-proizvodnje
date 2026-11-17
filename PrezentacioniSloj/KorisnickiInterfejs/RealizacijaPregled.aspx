<%@ Page Title="Pregled realizacija" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RealizacijaPregled.aspx.cs" Inherits="KorisnickiInterfejs.RealizacijaPregled" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-5">
        <div class="d-flex justify-content-between align-items-center mb-3">
            <h2 class="mb-0">Pregled realizacija</h2>
        </div>
        <hr />

        <asp:UpdatePanel ID="upRealizacije" runat="server">
            <ContentTemplate>
                <div class="row g-4">
                    <div class="col-lg-6 col-md-12">
                        <div class="card shadow-sm h-100">
                            <div class="card-body">
                                <h4 class="card-title mb-3">Realizacija delova</h4>

                                <div class="d-flex flex-wrap align-items-center mb-3">
                                    <asp:Label ID="lblFilterDelova" runat="server" Text="ID:" CssClass="mr-2 mb-2" />
                                    <asp:TextBox ID="txtFilterDelova" runat="server" CssClass="form-control mr-2 mb-2" Width="120px" />
                                    <asp:Button ID="btnPretraziDelove" runat="server" Text="Pretraži" CssClass="btn btn-primary mb-2 mr-2" OnClick="btnPretraziDelove_Click" />
                                    <asp:Button ID="btnPrikaziSveDelove" runat="server" Text="Prikaži sve" CssClass="btn btn-secondary mb-2" OnClick="btnPrikaziSveDelove_Click" />
                                </div>

                                <div class="table-responsive">
                                    <asp:GridView ID="gvRealizacijaDelova" runat="server"
                                        CssClass="table table-striped table-hover align-middle"
                                        AutoGenerateColumns="False" AllowPaging="True" PageSize="10"
                                        OnPageIndexChanging="gvRealizacijaDelova_PromenaStrane"
                                        OnRowEditing="gvRealizacijaDelova_IzmenaReda"
                                        OnRowCancelingEdit="gvRealizacijaDelova_OtkazIzmene"
                                        OnRowUpdating="gvRealizacijaDelova_AzuriranjeReda"
                                        OnRowDeleting="gvRealizacijaDelova_BrisanjeReda"
                                        OnRowDataBound="gvRealizacijaDelova_PopunjavanjeRedaPodacima"
                                        DataKeyNames="RealizacijaDelovaID">
                                        <Columns>
                                            <asp:BoundField DataField="RealizacijaDelovaID" HeaderText="ID" />
                                            <asp:BoundField DataField="DatumRealizacije" HeaderText="Datum realizacije" DataFormatString="{0:dd.MM.yyyy}" />
                                            <asp:BoundField DataField="NazivDela" HeaderText="Naziv dela" />
                                            <asp:BoundField DataField="RealizovanaKolicina" HeaderText="Količina" />
                                            <asp:TemplateField HeaderText="Sektor">
                                                <ItemTemplate>
                                                    <%# Eval("NazivSektora") %>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlSektorDelovi" runat="server" CssClass="form-control"></asp:DropDownList>
                                                </EditItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnIzmeni" runat="server" CommandName="Edit">Izmeni</asp:LinkButton>
                                                    <asp:LinkButton ID="btnObrisi" runat="server" CommandName="Delete">Obriši</asp:LinkButton>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:LinkButton ID="btnSacuvaj" runat="server" CommandName="Update" CssClass="btn btn-sm btn-success me-1">Sačuvaj</asp:LinkButton>
                                                    <asp:LinkButton ID="btnOtkazi" runat="server" CommandName="Cancel"  CssClass="btn btn-sm btn-secondary">Otkaži</asp:LinkButton>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>

                                <asp:Label ID="lblInfoDelovi" runat="server" CssClass="text-muted small" />
                            </div>
                        </div>
                    </div>

                    <div class="col-lg-6 col-md-12">
                        <div class="card shadow-sm h-100">
                            <div class="card-body">
                                <h4 class="card-title mb-3">Realizacija proizvoda</h4>

                                <div class="d-flex flex-wrap align-items-center mb-3">
                                    <asp:Label ID="lblFilterProizvoda" runat="server" Text="ID:" CssClass="mr-2 mb-2" />
                                    <asp:TextBox ID="txtFilterProizvoda" runat="server" CssClass="form-control mr-2 mb-2" Width="120px" />
                                    <asp:Button ID="btnPretraziProizvode" runat="server" Text="Pretraži" CssClass="btn btn-success mb-2 mr-2" OnClick="btnPretraziProizvode_Click" />
                                    <asp:Button ID="btnPrikaziSveProizvode" runat="server" Text="Prikaži sve" CssClass="btn btn-secondary mb-2" OnClick="btnPrikaziSveProizvode_Click" />
                                </div>

                                <div class="table-responsive">
                                    <asp:GridView ID="gvRealizacijaProizvoda" runat="server"
                                        CssClass="table table-striped table-hover align-middle"
                                        AutoGenerateColumns="False" AllowPaging="True" PageSize="10"
                                        OnPageIndexChanging="gvRealizacijaProizvoda_PromenaStrane"
                                        OnRowEditing="gvRealizacijaProizvoda_IzmenaReda"
                                        OnRowCancelingEdit="gvRealizacijaProizvoda_OtkazIzmene"
                                        OnRowUpdating="gvRealizacijaProizvoda_AzuriranjeReda"
                                        OnRowDeleting="gvRealizacijaProizvoda_BrisanjeReda"
                                        OnRowDataBound="gvRealizacijaProizvoda_PopunjavanjeRedaPodacima"
                                        DataKeyNames="RealizacijaProizvodaID">
                                        <Columns>
                                            <asp:BoundField DataField="RealizacijaProizvodaID" HeaderText="ID" />
                                            <asp:BoundField DataField="DatumRealizacije" HeaderText="Datum realizacije" DataFormatString="{0:dd.MM.yyyy}" />
                                            <asp:BoundField DataField="NazivProizvoda" HeaderText="Naziv proizvoda" />
                                            <asp:BoundField DataField="RealizovanaKolicina" HeaderText="Količina" />
                                            <asp:TemplateField HeaderText="Sektor">
                                                <ItemTemplate>
                                                    <%# Eval("NazivSektora") %>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlSektorProizvodi" runat="server" CssClass="form-control"></asp:DropDownList>
                                                </EditItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnIzmeni" runat="server" CommandName="Edit">Izmeni</asp:LinkButton>
                                                    <asp:LinkButton ID="btnObrisi" runat="server" CommandName="Delete">Obriši</asp:LinkButton>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:LinkButton ID="btnSacuvaj" runat="server" CommandName="Update" CssClass="btn btn-sm btn-success me-1">Sačuvaj</asp:LinkButton>
                                                    <asp:LinkButton ID="btnOtkazi" runat="server" CommandName="Cancel"  CssClass="btn btn-sm btn-secondary">Otkaži</asp:LinkButton>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>

                                <asp:Label ID="lblInfoProizvodi" runat="server" CssClass="text-muted small" />
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

</asp:Content>
