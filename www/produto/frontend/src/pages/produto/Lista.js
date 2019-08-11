import React, { useEffect, useState } from 'react';
import api from '../../services/api';

import './Lista.css';

export default function Lista( { history } ) {

    const [produtos, setProdutos] = useState([]);

    useEffect(() => {
        async function obtemProdutos() {
            const response = await api.get('/Produto');    
            // toda vez que o useStates é alterado, o componente é renderizado novamente
            setProdutos(response.data);            
        }
        obtemProdutos();
    }, []);

    async function handleCria() {
        console.log('Cria');
        history.push('./Cria');
    }
    async function handleAltera(id) {
        console.log('Altera');
        history.push(`./Altera/${id}`);
    }
    async function handleExclui(id) {
        console.log('Exclui');
        history.push(`./Exclui/${id}`);
    }

    return (
        //use className, pois class é uma palavra chave do JS       
        <div className="lista-container">

            <table>
                <thead>
                    <tr>
                        <th id="menu" colSpan="4">
                        <button
                type="button"
                onClick={() => handleCria()}>
                criar
            </button>
                        </th>
                    </tr>
                    
                    <tr>
                        <th>Descrição</th>
                        <th>Quantidade</th>
                        <th>Valor (R$)</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>                    
                    {
                        // map percorre todo o array
                        produtos.map(produto => (
                            <tr key={produto.id}>
                                <td>{produto.descricao}</td>
                                <td>{produto.quantidade}</td>
                                <td>{produto.valor}</td>
                                <td>
                                    <button
                                        type="button"
                                        id="altera"
                                        onClick={() => handleAltera(produto.id)}>
                                        alterar
                                    </button>
                                    &nbsp;
                                    <button
                                        type="button"
                                        id="exclui"
                                        onClick={() => handleExclui(produto.id)}>
                                        excluir
                                    </button>
                                </td>
                            </tr>
                        ))
                    }                
                </tbody>
            </table>
            
        </div>
    );
}