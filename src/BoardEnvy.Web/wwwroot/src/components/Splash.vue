<template>
  <div class="container body-content">
    <app-nav></app-nav>

      <div class="hello">
        <h2>{{ msg }}</h2>
      </div>
    
<div>
          <span v-for="(item, index) in items">
              <h1>{{item.name}}</h1>
                    <p>
                <a class="btn btn-default" :href="item.url">
                  Practice
                </a>
                    </p>
          </span>
</div>


    <app-footer></app-footer>
  </div>
</template>

<script>

import Nav from '../components/Nav'
import Footer from '../components/Footer'

  export default {
    name: 'splash',
    data() {
      return {
        msg: 'Loading boards...',
        items: null
      }
    },
    components: {
      'app-nav': Nav,
      'app-footer': Footer
    },
    created () {
      var _this = this;
        $.getJSON('/api/boards', function (json) {
            _this.items = $.map(json, (o, i) => {
                        return {
                            "name": o.name,
                            "id": o.boardKey,
                            "url": `/board.html#/${o.boardKey}/overview`
                        }
                    })
            _this.msg = "Your boards...";
        })
    }
  } 
</script>