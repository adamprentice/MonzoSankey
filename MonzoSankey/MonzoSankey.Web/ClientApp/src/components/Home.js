import React, { Component } from 'react';


export class Home extends Component {
    displayName = Home.name

    constructor( props ) {
        super( props );
        this.state = { nodes: [], links: [], userId: null, loading: true };
    }

    render() {
    return (
        <div>
            <a className="btn btn-lg btn-primary" href="/auth/login">Sign in with Monzo</a>
        </div>
    );
  }
}
