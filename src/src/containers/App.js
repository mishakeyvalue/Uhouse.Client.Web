import React, { Component } from 'react';
import logo from './../logo.svg';
import './App.css';

import MockPins from './MockPins';

class App extends Component {
  render() {
    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h1 className="App-title">Uhouse control panel</h1>
        </header>
        <p className="App-intro">
        </p>
        <MockPins />
      </div>
    );
  }
}

export default App;
