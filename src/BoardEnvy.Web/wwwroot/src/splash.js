import Vue from 'vue'
import BrowserUtil from './js/BrowserUtil'
import Splash from './components/Splash'

import "vueify/lib/insert-css"

Vue.config.productionTip = false

/* eslint-disable no-new */
new Vue({
    el: '#splash',
    render: h => h(Splash),
    components: {
        Splash
    }
})