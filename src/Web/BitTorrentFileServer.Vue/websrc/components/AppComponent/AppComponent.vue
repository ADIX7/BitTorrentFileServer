<script>
import BrowseComponent from "../BrowseComponent/BrowseComponent.vue";
import NavbarComponent from "../NavbarComponent.vue";
import TorrentComponent from "../TorrentComponent/TorrentComponent.vue";
import "bootstrap";

export default {
  components: {
    BrowseComponent,
    NavbarComponent,
    TorrentComponent
  },
  data() {
    return {
      pathParts: [{ name: "." }],
      browseContent: {
        path: ".",
        content: []
      },
      currentView: "browse"
    };
  },
  methods: {
    updateFolder(path) {
      path = path || ".";
      let _this = this;

      fetch("/api/content/" + btoa(path))
        .then(function(response) {
          return response.json();
        })
        .then(function(content) {
          _this.browseContent = content;

          _this.pathParts = [];
          content.path.split("/").forEach(element => {
            _this.pathParts.push({ name: element });
          });
        });
    }
  },
  created: function() {
    this.updateFolder();
  }
};
</script>

<template src="./AppComponent.html">  
</template>

<style lang="scss">

</style>


