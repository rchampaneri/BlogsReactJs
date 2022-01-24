import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';


import './custom.css'
import { Blogs } from './components/Blog/Blogs';
import { View } from './components/Blog/View';

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Blogs} />
        <Route path='/view/:id' component={View} />
      </Layout>
    );
  }
}
