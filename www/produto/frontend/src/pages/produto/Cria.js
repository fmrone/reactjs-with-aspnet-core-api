import React, { useState } from 'react';
import api from '../../services/api';

import './Formulario.css';

// propriedade history - herdada do react-router-dom (navegação)

export default function Cria( { history } ) {
    
    // inicializa os campos
    const [descricao, setDescricao] = useState('');
    const [quantidade, setQuantidade] = useState('');
    const [valor, setValor] = useState('');

    async function handleSubmit(e) {
        // cancela o POST
        e.preventDefault();

        const response = await api.post('Produto', {
            id: 0,
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
        history.push('./');
    }

    return (        
        <div className="formulario-container">
            <form onSubmit={handleSubmit}>
                <legend>PRODUTO</legend>
                <hr></hr>
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
                    <button type="submit">Criar</button>    
                    <button
                        type="button"
                        onClick={() => history.push('./')}>
                        Voltar
                    </button>    
                </footer>     
            </form>
        </div>
    );
}