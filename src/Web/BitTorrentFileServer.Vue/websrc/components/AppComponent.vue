<template>
  <div>
    <NavbarComponent></NavbarComponent>
    <BrowseComponent
      v-bind:pathParts="pathParts"
      v-bind:content="browseContent"
      v-on:navigate-to="updateFolder"
    ></BrowseComponent>
  </div>
</template>

<script>
import NavbarComponent from "./NavbarComponent.vue";
import BrowseComponent from "./BrowseComponent.vue";

export default {
  components: {
    NavbarComponent,
    BrowseComponent
  },
  data() {
    return {
      pathParts: [{ name: "." }],
      browseContent: {
        path: ".",
        content: []
      }
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

<style lang="sass">

</style>


