<template>
  <nav class="navbar navbar-expand-md navbar-dark bg-dark">
    <a class="navbar-brand" href="#">Torrent File Server</a>
    <button
      class="navbar-toggler navbar-dark"
      type="button"
      data-toggle="collapse"
      data-target="#mainNavBar"
      aria-controls="mainNavBar"
      aria-expanded="false"
      aria-label="Toggle navigation"
    >
      <span class="navbar-toggler-icon"></span>
    </button>

    <div class="collapse navbar-collapse" id="mainNavBar">
      <ul class="navbar-nav mr-auto">
        <li v-bind:class="[{active: currentView === 'browse'}, 'nav-item']">
          <a class="nav-link" href="#" v-on:click="$emit('open-view', 'browse')">Browse</a>
        </li>
        <li v-bind:class="[{active: currentView === 'torrents'}, 'nav-item']">
          <a class="nav-link" href="#" v-on:click="$emit('open-view', 'torrents')">Torrents</a>
        </li>
      </ul>
    </div>
  </nav>
</template>

<script>
export default {
  props: ["currentView"]
};
</script>
