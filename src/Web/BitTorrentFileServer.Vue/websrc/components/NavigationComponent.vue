<template>
    <nav aria-label="breadcrumb">
        <ol class="breadcrumb">
            <li class="breadcrumb-item"><a href="#">Home</a></li>
            <li class="breadcrumb-item"><a href="#">Library</a></li>
            <li class="breadcrumb-item active" aria-current="page">{{ msg }}</li>
        </ol>
    </nav>
</template>

<script>
module.exports = {
    data: function(){
        return {
            msg: "init msg"
        }
    }
}
</script>


<style lang="scss">
</style>