import React, { Component } from 'react';

export class Home extends Component {
    displayName = Home.name

    constructor( props ) {
        super( props );
        this.state = { transactionCount: 0, loading: true };

        fetch( 'api/Transaction/Transactions' )
            .then( response => response.json() )
            .then( data => {
                this.setState( { transactionCount: data, loading: false } );
            } );
    }


    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : <p>The amount of transactions is {this.state.transactionCount}</p>;

    return (
      <div>
        <h1>Hello, world!</h1>
        <p>Welcome to your new single-page application, built with:</p>
        {contents}
      </div>
    );
  }
}
