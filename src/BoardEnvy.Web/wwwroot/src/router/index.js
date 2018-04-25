import Vue from 'vue'
import Router from 'vue-router'

import Hello from '../components/Hello'
import BoardDetails from '../components/BoardDetails'
import HubTest from '../components/HubTest'
import Practice from '../components/Practice'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Hello',
      component: Hello
    },
    {
      path: '/boards/:id/overview',
      name: 'BoardDetails',
      component: BoardDetails
    },
    {
      path: '/circuits/:id/hubtest',
      name: 'HubTest',
      component: HubTest
    },
    {
      path: '/circuits/:id/practice',
      name: 'Practice',
      component: Practice
    },
    {
      path: '*',
      redirect: '/'
    }
  ]
})