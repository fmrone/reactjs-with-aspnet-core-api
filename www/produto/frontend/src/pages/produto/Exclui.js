import React, { useEffect, useState } from 'react';
import api from '../../services/api';

import './Exclui.css';

// useEffect - função que é executada assim que o componente for renderizado
// match contem todos os parêmetros passados para essa rota

export default function Exclui( { match, history } ) {
    
    // inicializa os campos
    const [id, setId] = useState('');
    const [descricao, setDescricao] = useState('');
    
    // params: função e qdo a função deve ser executada.
    // ao passar um parâmetro vazio [], a função é executada uma única vez.
    // toda vez que a variável for alterada, a função é executada. Ou seja, toda vez que o parâmetro id for alterado, a função será executada.
    
    useEffect(() => {
        async function obtemProduto() {
            const response = await api.get(`/Produto/${match.params.id}`);
                
            setId(response.data.id);
            setDescricao(response.data.descricao);    
        }
        obtemProduto();
    }, [match.params.id]);

    async function handleConfirma(id) {
        console.log('Conforma exclusão');

        const response = await api.delete(`Produto/${id}`);

        console.log(response);
        
        history.push('../');
    }
    
    async function handleDesiste() {
        console.log('Desiste');
        history.push('../');
    }
    
    return (
        <div className="exclui-container">
            <div>
                <p>Você deseja realmente excluir o produto {descricao}?</p>
                <footer>
                    <button
                        type="button"
                        id="confirma"
                        onClick={() => handleConfirma(id)}>
                        sim
                    </button>
                    <button
                        type="button"
                        id="desiste"
                        onClick={() => handleDesiste()}>
                        não
                    </button>
                </footer>
            </div>            
        </div>        
    );
}