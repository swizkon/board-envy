<template>
  <div class="container body-content">
    <app-nav></app-nav>

      <div class="hello">
        <h2>{{ msg }}</h2>
      </div>
      <div>
        <form @submit.prevent="handleSubmit">
          <label>
            New board:
            <input type="text" placeholder="Enter board name" v-model="board.name"/>
          </label>
          <button type="submit">Create board</button>
        </form>
      </div>
    
<div>
          <span v-for="(item, index) in items">
                    <p>
                <a class="btn btn-default" :href="item.url">
                  <h1>{{item.name}}</h1>
                </a>
                    </p>
          </span>
</div>


    <app-footer></app-footer>
  </div>
</template>

<script>
import BrowserUtil from "../js/BrowserUtil"
import Nav from '../components/Nav'
import Footer from '../components/Footer'

  export default {
    name: 'splash',
    data() {
      return {
        msg: 'Loading boards...',
        items: null,
        board: {
          name: ''
        }
      }
    },
    components: {
      'app-nav': Nav,
      'app-footer': Footer
    },
    created () {
      var _this = this;
      BrowserUtil.getJSON('/api/boards', function (json) {
            _this.items = $.map(json, (o, i) => {
                        return {
                            "name": o.name,
                            "id": o.boardKey,
                            "url": `/board.html#/boards/${o.boardKey}/overview`
                        }
                    })
            _this.msg = "Your boards...";
        })
    },
    methods: {
      handleSubmit() {
      var _this = this;
        // Send data to the server or update your stores and such.
        BrowserUtil.sendJSON('/api/boards', {name: _this.board.name}, function (json) {
                    console.log(arguments);
        })
        _this.board.name = "";
      }
    }
  } 
</script>