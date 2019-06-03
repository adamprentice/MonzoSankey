import React, { Component } from 'react';
import {Sankey} from 'react-vis';


export class Home extends Component {
    displayName = Home.name

    constructor( props ) {
        super( props );
        this.state = { nodes: [], links: [], userId: null, loading: true };

        fetch( 'api/Transaction/Transactions' )
            .then( response => response.json() )
            .then( data => {
                this.setState( { nodes: data.nodes, links: data.links, loading: false } );
            } );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : <Sankey nodes={this.state.nodes} links={this.state.links} width={1000} height={800}/>;

    return (
      <div>       
        {contents}
      </div>
    );
  }
}
