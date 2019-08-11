import React, { useEffect, useState } from 'react';
import api from '../../services/api';

import './Formulario.css';

// useEffect - função que é executada assim que o componente for renderizado
// match contem todos os parêmetros passados para essa rota

export default function Altera( { match, history } ) {
    
    // inicializa os campos
    const [id, setId] = useState('');
    const [descricao, setDescricao] = useState('');
    const [quantidade, setQuantidade] = useState('');
    const [valor, setValor] = useState('');

    // params: função e qdo a função deve ser executada.
    // ao passar um parâmetro vazio [], a função é executada uma única vez.
    // toda vez que a variável for alterada, a função é executada. Ou seja, toda vez que o parâmetro id for alterado, a função será executada.
    
    useEffect(() => {
        async function obtemProduto() {
            const response = await api.get(`/Produto/${match.params.id}`);
                
            setId(response.data.id);
            setDescricao(response.data.descricao);
            setQuantidade(response.data.quantidade);
            setValor(response.data.valor);
        }
        obtemProduto();
    }, [match.params.id]);

    async function handleSubmit(e) {
        // cancela o POST
        e.preventDefault();

        const response = await api.put('Produto', {
            id,
            descricao,
            quantidade,
            valor              
        }, {
            headers: {
                'Content-Type': 'application/json',
                'Access-Control-Allow-Origin': 'http://localhost:3000'
              }
        });

        console.log(response);

        // redireciona para Lista
        history.push('../');
    }
    
    return (
        <div className="formulario-container">
            <form onSubmit={handleSubmit}>
                <legend>PRODUTO</legend>
                <hr />
                <input
                    placeholder="Descrição do produto"
                    maxLength="100"
                    value={descricao}         
                    onChange={e => setDescricao(e.target.value)}           
                />
                <input
                    placeholder="Quantidade"
                    maxLength="10"
                    value={quantidade}         
                    onChange={e => setQuantidade(e.target.value)}  
                />
                <input
                    placeholder="Valor"
                    maxLength="10"
                    value={valor}         
                    onChange={e => setValor(e.target.value)}  
                />
                <footer>
                    <button type="submit">Alterar</button>    
                    <button
                        type="button"
                        onClick={() => history.push('../')}>
                        Voltar
                    </button>        
                </footer>                
            </form>
        </div>        
    );
}