const btAdd = document.getElementById('btnAdd');
const table = document.querySelector('table');
const btRemove = document.getElementById('btnRemove');


btAdd.addEventListener('click', (e) => {
    e.preventDefault();
    let template = `<tr>
                                <td>
                                    <input class="inpt_orc" id="cod_input" type="text" /><asp:Label runat="server" ID="lblIDProduto"></asp:Label></td>
                                <td>
                                    <input class="inpt_orc" id="desc_input" type="text" /></td>
                                <td>
                                    <input class="inpt_orc" id="qtd_input" type="text" /><asp:TextBox runat="server" type="number" name="quantidade" class="input_qtd_prod_orc" ID="txtQuantidadeProduto" OnTextChanged="txtQuantidadeProduto_TextChanged" Width="54px"></asp:TextBox></td>
                                <td>
                                    <input class="inpt_orc" id="vunit_input" type="text" /><asp:Label runat="server" ID="lblVlrUni"></asp:Label></td>
                                <td>
                                    <input class="inpt_orc" id="subt_input" type="text" /><asp:Label runat="server" ID="lblSubtPd"></asp:Label></td>
                            </tr>`
    table.innerHTML += template;
  
});


